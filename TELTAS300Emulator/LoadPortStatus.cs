using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TELTAS300Emulator
{
    public enum SlotStatus
    {
        NoWafer = 0,
        Wafer,
        Crossed,
        [EnumMember(Value ="?")]
        Undefined,
        [EnumMember(Value = "W")]
        Overlapping
    }
    public enum LoadPorts
    {
        Port1=0,
        Port2,
        Port3,
        Port4
    }
    public enum LoadPortStatus
    {
        Unknown = 0,
        NotInitialized,
        Initialized,
        Faulted,
        FoupLoaded,
        FoupUnloaded,
        FoupClamped,
        FoupNotClamped,
        FoupLoadedAndMapped
    }

    public enum NAKParams
    {
        CKSUM,
        CMDER,
        INTER
    }

    public enum NAKWarnings
    {
        CBUSY,
        CLDDK,
        CLOAD,
        CMDER,
        CULDK,
        DPOSI,
        DVACM,
        ERROR,
        FPILG,
        LATCH,
        MPARM,
        MPSTP,
        ORGYT,
        RMPOS,
        YPOSI,
        ZPOSI
    }

    public enum BeforeInterLocks
    {
        CBUSY,
        CLDDK,
        CLOAD,
        CULDK,
        DPOSI,
        DVACM,
        ERROR,
        FPILG,
        LATCH,
        MPARM,
        MPSTP,
        ORGYT,
        YPOSI,
        ZPOSI
    }

    public enum AfterInterLocks
    {
        AIRSN,
        CLCLS,
        DLMIT,
        DRCLS,
        FANST,
        INTCL,
        INTOP,
        MPBAR,
        MPEDL,
        PROTS,
        SAFTY,
        VACCS,
        YLMIT
    }

    public enum ForceErrorType
    {
        Rejection_Reply,
        Interlock
    }

    public class ForceErrorContext
    {
        public int LoadPortNum { get; }
        public ForceErrorType? ErrorType { get; }
        public NAKParams? NAKParams { get; }
        public NAKWarnings? NAKWarnings { get; }
        public bool IsBefore { get; }
        public BeforeInterLocks? BeforeInterLock { get; }
        public AfterInterLocks? AfterInterLock { get; }

        public ForceErrorContext(int port, ForceErrorType? errType, NAKParams? nakParams, NAKWarnings? nakWarn, bool isBefore, BeforeInterLocks? beforeInterlock,
            AfterInterLocks? afterInterlock)
        {
            LoadPortNum = port;
            ErrorType = errType;
            NAKParams = nakParams;
            NAKWarnings = nakWarn;
            IsBefore = isBefore;
            BeforeInterLock = beforeInterlock;
            AfterInterLock = afterInterlock;
        }
    }

    public class LoadPortState
    {
        public EquipmentStatus equipmentStatus;
        public Mode mode;
        public InitialPosition initialPosition;
        public OPerationStatus OPerationStatus;
        public Char ErrorCodeUpper = '0';
        public Char ErrorCodeLower='0';
        public CasettePresence casettePresence;
        public FOUPClampStatus fOUPClampStatus;
        public LatchKeyStatus latchKeyStatus;
        public Vacuum vacuum;
        public DoorPosition doorPosition;
        public WaferProtrusionSensor waferProtrusionSensor;
        public ZAxisPosition zAxisPosition;
        public YAxisPosition yAxisPosition;
        public MapperArmPosition mapperArmPosition;
        public MapperZAxis mapperZAxis;
        public MapperStopper mapperStopper;
        public MappingStatus mappingStatus;
        public InterlockKey interlockKey;
        public InfoPad infoPad;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('/');
            switch(equipmentStatus)
            {
                case EquipmentStatus.Normal:
                    sb.Append('0');
                    break;
                case EquipmentStatus.RecoverableError:
                    sb.Append('A');
                    break;
                case EquipmentStatus.FatalError:
                    sb.Append('E');
                    break;
            }
            sb.Append(((int)mode));
            sb.Append(((int)initialPosition));
            sb.Append(((int)OPerationStatus));
            sb.Append(ErrorCodeUpper);
            sb.Append(ErrorCodeLower);
            sb.Append(((int)casettePresence));
            sb.Append(fOUPClampStatus==FOUPClampStatus.NotDefined?"?": ((int)fOUPClampStatus).ToString());
            sb.Append(latchKeyStatus == LatchKeyStatus.NotDefined?"?": ((int)latchKeyStatus).ToString());
            sb.Append(((int)vacuum));
            sb.Append(doorPosition == DoorPosition.NotDefined ? "?" : ((int)doorPosition).ToString());
            sb.Append(((int)waferProtrusionSensor));
            sb.Append(zAxisPosition == ZAxisPosition.NotDefined ? "?" : ((int)zAxisPosition).ToString());
            sb.Append(yAxisPosition == YAxisPosition.NotDefined ? "?" : ((int)yAxisPosition).ToString());
            sb.Append(mapperArmPosition == MapperArmPosition.NotDefined ? "?" : ((int)mapperArmPosition).ToString());
            sb.Append(mapperZAxis == MapperZAxis.NotDefined ? "?" : ((int)mapperZAxis).ToString());
            sb.Append(mapperStopper == MapperStopper.NotDefined ? "?" : ((int)mapperStopper).ToString());
            sb.Append(((int)mappingStatus));
            sb.Append(((int)interlockKey));
            sb.Append(((int)infoPad));

            return sb.ToString();
        }
    }   

    public enum EquipmentStatus
    {
        Normal =0,RecoverableError,FatalError
    }

    public enum Mode
    {
        Online =0,Teaching
    }

    public enum InitialPosition
    {
        Unexecuted =0,Executed
    }

    public enum OPerationStatus
    {
        Stopped =0,OPerating
    }

    public enum CasettePresence
    {
        None =0,NormalPosition,ErrorLoad
    }

    public enum FOUPClampStatus
    {
        Open =0,Close,NotDefined
    }

    public enum LatchKeyStatus
    {
        Open =0,Close,NotDefined
    }

    public enum Vacuum
    {
        OFF =0,ON
    }

    public enum DoorPosition
    {
        OpenPosition =0,ClosePosition,NotDefined
    }

    public enum WaferProtrusionSensor
    {
        Blocked =0,Unblocked
    }

    public enum ZAxisPosition
    {
        UpPosition =0,DownPosition,StartPosition,EndPosition,NotDefined
    }

    public enum YAxisPosition
    {
        UndockPosition =0,DockPosition,NotDefined
    }

    public enum MapperArmPosition
    {
        Open =0,Close,NotDefined
    }

    public enum MapperZAxis
    {
        RetractPosition =0,MappingPosition,NotDefined
    }

    public enum MapperStopper
    {
        ON =0,OFF,NotDefined
    }

    public enum MappingStatus
    {
        UnExecuted =0,NormalEnd,AbnormalEnd
    }

    public enum InterlockKey
    {
        Enable =0,Disable
    }

    public enum InfoPad
    {
        NoInput =0,APinON,BPinON,AOrBPinON
    }
}
