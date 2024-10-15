using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class ServerNit
    {
        Socket _socketListen;
        readonly List<Socket> _users = new List<Socket>();

        private static ServerNit _instance;
        private ServerNit()
        {

        }
        public static ServerNit Instance => _instance ?? (_instance = new ServerNit());

        public bool Start()
        {
            try
            {
                _socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9090);
                _socketListen.Bind(ipEndPoint);
                _socketListen.Listen(5);
                _users.Add(_socketListen);
                new Thread(Listen).Start();
                return true;
            }
            catch (SocketException)
            {
                _socketListen.Close();
                return false;
            }
            catch (IOException)
            {
                _socketListen.Close();
                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                foreach (var user in _users)
                {
                    user.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Listen()
        {
            var end = false;
            while (!end)
            {
                try
                {
                    var user = _socketListen.Accept();
                    _users.Add(user);
                    new Thread(new KlijentNit(user).HandleUser).Start();
                }
                catch (SocketException)
                {
                    end = true;
                }
                catch (IOException)
                {
                    end = true;
                }
            }
        }
    }
}
