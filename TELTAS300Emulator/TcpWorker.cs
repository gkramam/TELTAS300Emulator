using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TELTAS300Emulator
{
    public class TcpWorker
    {
        private readonly int _tcpWorkerLoopIdleTime;

        public event EventHandler Connected;
        public event EventHandler Disconnected;

        private TcpListener _listener;
        //private List<TcpClient> _connections;
        private List<TcpConnection> _connections;

        private TcpConnection _activeConnection;
        public TcpConnection ActiveConnection { get { return _activeConnection; } }

        private bool _started = false;

        public readonly int Port;
        bool Stop = false;

        public TcpWorker(int portNumber)
        {
            _connections = new List<TcpConnection>();
            //Stop = false;
            Port = portNumber;
            _tcpWorkerLoopIdleTime = AppConfiguration.tcpWorkerLoopIdleTime;
            _listener = TcpListener.Create(Port);
        }

        void OnConnected()
        {
            Connected?.Invoke(this, new EventArgs());
        }

        void OnDisConnected()
        {
            Disconnected ?.Invoke(this, new EventArgs());
        }

        public void StopWorker()
        {
            Stop = false;
            //foreach (var c in _connections)
            //{
            //    c.Stop = true;
            //}
        }
        public void Start(Action<CommandContext> addToQCallback)
        {
            if (_started || Stop || _listener == null)
                return;
            try
            {
                _connections.Clear();// allowing for extenstion should multiple connections need be suported
                _listener.Start(Int32.MaxValue);
                _started = true;

                while (!Stop) // Listener Loop
                {
                    if (_listener.Pending())
                    {
                        var conn = _listener.AcceptTcpClient();
                        if (conn != null)
                        {
                            var tcpconn = new TcpConnection(conn);
                            _connections.Add(tcpconn);
                            _activeConnection = tcpconn;
                            tcpconn.Disconnected += (x, y) => { OnDisConnected(); };
                            tcpconn.Start(addToQCallback);
                            OnConnected();
                        }
                    }

                    Thread.Sleep(_tcpWorkerLoopIdleTime);
                }

                foreach (var c in _connections)
                {
                    c.Stop = true;
                }
            }
            catch (SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Tcpconn_Disconnected(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
