using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TELTAS300Emulator
{
    public class LoadPort
    {
        public LoadPortStatus Status { get; set; }

        public LoadPortState State { get; set; }

        public BlockingCollection<CommandContext> IncomingQ;
        TcpWorker tcpListener;

        public Casette Casette { get; }

        bool _stop;
        public bool Stop 
        { 
            get { return _stop; }
            set 
            {
                _stop = value;
                if (value)
                    tcpListener.StopWorker();
            } 
        }

        bool _started = false;
        public bool Started { get => _started; }

        static readonly object _lock = new object();
        bool _forceErrorForFutureCommands;
        public bool ForceErrorForFutureCommands 
        { 
            get 
            {
                lock (_lock)
                {
                    return _forceErrorForFutureCommands;
                }
            }
            set 
            {
                lock (_lock)
                {
                    _forceErrorForFutureCommands = value;
                    if (!value)
                        Status = LoadPortStatus.Initialized;
                }
            } 
        }

        public ForceErrorContext ForceErrorContext { get; set; }

        string addressString = string.Empty;
        public LoadPort(int portNum, int index)
        {
            IncomingQ = new BlockingCollection<CommandContext>();
            tcpListener = new TcpWorker(portNum);
            Status = LoadPortStatus.Unknown;
            State = new LoadPortState();
            ForceErrorContext = null;
            addressString = index.ToString("D2");
            Casette = new Casette(AppConfiguration.NumberOfSlotsInCasette);
        }
        public void AddToIncomingQ(CommandContext commandContext)
        {
            IncomingQ.Add(commandContext);
        }
        public void Start()
        {
            Task.Run(() => { tcpListener.Start(AddToIncomingQ);});

            Task.Run(() =>
            {
                foreach (var cmdctxt in IncomingQ.GetConsumingEnumerable())
                {
                    Process(cmdctxt);
                    if (_stop)
                        break;
                }
            });

            Task.Run(() => 
            {
                while (tcpListener.ActiveConnection == null)
                    Thread.Sleep(1);

                if(tcpListener.ActiveConnection.InnerConnection.Connected)
                {
                    _started = true;
                    SendEvent(false, "E84IO", "/00/80",null);
                    SendEvent(false, "PODOF", null, null);
                }
            });

        }

        bool isWaferProtrusionSensorInterLock;
        public bool IsWaferProtrusionSensorInterLock
        {
            get
            {
                lock(_lock)
                {
                    return isWaferProtrusionSensorInterLock;
                }
            }
            set
            {
                lock(_lock)
                {
                    isWaferProtrusionSensorInterLock = value;
                    State.waferProtrusionSensor = value ? WaferProtrusionSensor.Blocked : WaferProtrusionSensor.Unblocked;
                    State.equipmentStatus = value ? EquipmentStatus.FatalError : EquipmentStatus.Normal;
                }
            }
        }

        bool isCarrierPlaced;
        public bool IsCarrierPlaced
        {
            get
            {
                lock(_lock)
                {
                    return isCarrierPlaced;
                }
            }
            set
            {
                lock(_lock)
                {
                    isCarrierPlaced = value;
                    State.casettePresence = value ? CasettePresence.NormalPosition : CasettePresence.None;
                    SendEvent(false, value ? "PODON" : "PODOF", null, null);
                }
            }
        }

        void Process(CommandContext ctxt)
        {
            var commandType = ctxt.CommandMessage.Substring(3, 3);
            var commandName = ctxt.CommandMessage.Substring(7, 5);

            if(IsWaferProtrusionSensorInterLock)
            {
                State.waferProtrusionSensor = WaferProtrusionSensor.Blocked;
                State.equipmentStatus = EquipmentStatus.FatalError;
                SendNAK(commandType, commandName, "/INTER", ctxt);
                return;
            }

            if(commandName.Equals("RESET"))
            {
                State = new LoadPortState() { waferProtrusionSensor = State.waferProtrusionSensor, casettePresence = State.casettePresence };
                Status = LoadPortStatus.NotInitialized;
                ForceErrorForFutureCommands = false;
                ForceErrorContext = null;
            }

            if (!ForceErrorForFutureCommands)
                PerformNormalProcessing(commandType,commandName,ctxt,true);
            else
            {
                if (ForceErrorContext != null)
                {
                    Status = LoadPortStatus.Faulted;
                    if(ForceErrorContext.ErrorType == ForceErrorType.Rejection_Reply)
                    {
                        SendNAK(commandType,
                            commandName,
                            $@"/{ForceErrorContext.NAKParams.ToString()}/{ForceErrorContext.NAKWarnings.ToString()}",
                            ctxt);
                    }
                    else if(ForceErrorContext.ErrorType == ForceErrorType.Interlock)
                    {
                        if(ForceErrorContext.IsBefore)
                        {
                            SendNAK(commandType,
                            //commandName,
                            "INTER",
                            $@"/{ForceErrorContext.BeforeInterLock.ToString()}",
                            ctxt);
                        }
                        else
                        {
                            UpdateState(commandName, false);
                            PerformNormalProcessing(commandType, commandName, ctxt,false);
                            if(commandType.Equals("SET")|| commandType.Equals("MOV"))
                                SendEvent(true,commandName, $@"/{ForceErrorContext.AfterInterLock.ToString()}", ctxt);
                            Status = LoadPortStatus.Faulted;
                        }
                    }
                }
            }
           
        }

        void SendEvent(bool isABS,string commandName, string parameter,CommandContext ctxt)
        {
            if (!_started)
                return;

            StringBuilder response = new StringBuilder();
            
            if(isABS)
                response.Append("ABS:");
            else
                response.Append("INF:");

            response.Append(commandName);
            
            if (!string.IsNullOrEmpty(parameter))
                response.Append(parameter);
            response.Append(";");

            var evnt = AddStartEndToMessage(response.ToString());

            if (ctxt!= null)
                ctxt.ResponseQCallback(evnt);
            else
            {
                tcpListener.ActiveConnection.QResponse(evnt);
            }

            if(isABS)
            {
                MarkFatalError(parameter);
            }
        }

       
        void PerformNormalProcessing(string commandType, string commandName, CommandContext ctxt, bool raiseEvent)
        {
            string parameter = string.Empty;

            switch (commandName)
            {
                case "VERSN":
                    parameter = "/VER 1.01    ";
                    break;
                case "LEDST":
                    parameter = "/0000000000000";
                    break;
                case "STATE":
                    parameter = State.ToString();
                    break;
                case "MAPDT":
                    parameter = $"/{Casette.ToString().Reverse()}";
                    break;
                case "MAPRD":
                    parameter = $"/{Casette.ToString()}";
                    break;
                case "WFCNT":
                    parameter = "/25";
                    break;
                case "CLOAD":
                    if (Status != LoadPortStatus.Initialized)
                    {
                        SendNAK(commandType, commandName, "/CMDER", ctxt);
                        return;
                    }
                    break;
                case "CLDDK":
                case "CLDYD":
                case "CLDMP":
                case "CLDOP":
                case "CLMPO":
                case "MAPDO":
                case "REMAP":
                    if (Status != LoadPortStatus.Initialized && Status != LoadPortStatus.FoupLoaded)
                    {
                        SendNAK(commandType, commandName, "/CMDER", ctxt);
                        return;
                    }
                    break;
                case "CULOD":
                case "CULDK":
                case "CUDCL":
                case "CUDNC":
                case "CULYD":
                case "CULFC":
                case "CUDMP":
                    if (Status != LoadPortStatus.FoupLoaded)
                    {
                        SendNAK(commandType, commandName, "/CMDER", ctxt);
                        return;
                    }
                    break;
            }

            SendACK(commandType, commandName, parameter, ctxt,raiseEvent);
            UpdateState(commandName,false);
        }

        void UpdateState(string commandName, bool isNAK)
        {
            switch(commandName)
            {
                case "INITL":
                    Status = !isNAK ? LoadPortStatus.Initialized : LoadPortStatus.NotInitialized;
                    break;
                case "ORGSH":
                    State.initialPosition = InitialPosition.Executed;
                    Status = !isNAK? LoadPortStatus.Initialized : LoadPortStatus.NotInitialized;
                    break;
                case "CLOAD":
                case "CLDDK":
                case "CLDOP":
                case "CLMPO":
                    Status = !isNAK ? LoadPortStatus.FoupLoaded : LoadPortStatus.FoupLoaded;
                    State.zAxisPosition = ZAxisPosition.DownPosition;
                    break;
                case "CLDYD":
                    Status = !isNAK ? LoadPortStatus.FoupLoaded : LoadPortStatus.FoupLoaded;
                    State.zAxisPosition = ZAxisPosition.DownPosition;
                    State.yAxisPosition = YAxisPosition.DockPosition;
                    break;
                case "CLDMP":
                    State.zAxisPosition = ZAxisPosition.DownPosition;
                    State.mappingStatus = MappingStatus.NormalEnd;
                    Status = !isNAK ? LoadPortStatus.FoupLoaded : LoadPortStatus.FoupLoaded;
                    break;
                case "MAPDO":
                case "REMAP":
                    State.mappingStatus = MappingStatus.NormalEnd;
                    Status = !isNAK? LoadPortStatus.FoupLoaded: LoadPortStatus.FoupLoaded;
                    break;
                case "CULOD":
                case "CULDK":
                case "CUDCL":
                case "CUDNC":
                case "CULFC":
                    State.zAxisPosition = ZAxisPosition.UpPosition;
                    State.yAxisPosition = YAxisPosition.UndockPosition;
                    Status = !isNAK ? LoadPortStatus.FoupUnloaded : LoadPortStatus.FoupLoaded;
                    break;
                case "CULYD":
                    State.zAxisPosition = ZAxisPosition.UpPosition;
                    State.yAxisPosition = YAxisPosition.DockPosition;
                    Status = !isNAK ? LoadPortStatus.FoupUnloaded : LoadPortStatus.FoupLoaded;
                    break;
                case "CUDMP":
                    State.mappingStatus = MappingStatus.NormalEnd;
                    State.zAxisPosition = ZAxisPosition.UpPosition;
                    State.yAxisPosition = YAxisPosition.UndockPosition;
                    Status = !isNAK ? LoadPortStatus.FoupUnloaded : LoadPortStatus.FoupLoaded;
                    break;
                    Status = !isNAK ? LoadPortStatus.FoupUnloaded : LoadPortStatus.FoupLoaded;
                    break;
            }
        }

        void SendACK(string commandType, string commandName, string parameter,CommandContext ctxt, bool raiseEvent)
        {
            StringBuilder response = new StringBuilder();
            response.Append("ACK:");
            response.Append(commandName);
            if (!string.IsNullOrEmpty(parameter))
                response.Append(parameter);
            response.Append(";");
            ctxt.ResponseQCallback(AddStartEndToMessage(response.ToString()));
            if(raiseEvent && (commandType.Equals("SET") || commandType.Equals("MOV")))
                SendEvent(false, commandName,null, ctxt);
        }

        void SendNAK(string commandType, string commandName, string parameter,CommandContext ctxt)
        {
            StringBuilder response = new StringBuilder();
            response.Append("NAK:");
            response.Append(commandName);
            response.Append(parameter);
            response.Append(";");
            ctxt.ResponseQCallback(AddStartEndToMessage(response.ToString()));
            MarkFatalError(parameter);
        }

        void MarkFatalError(string parameter)
        {
            if (!string.IsNullOrEmpty(parameter) && FatalErrors.All.Any(p => p.Equals(parameter.Substring(1))))
                State.equipmentStatus = EquipmentStatus.FatalError;
            else
                State.equipmentStatus = EquipmentStatus.RecoverableError;
        }
        string AddStartEndToMessage(string message)
        {
            return $"s{addressString}{message}\r\n";
        }
    }
}
