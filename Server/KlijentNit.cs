using System;
using Domen.Util;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Domen.Entiteti;

namespace Server
{
    public class KlijentNit
    {
        readonly BinaryFormatter _formatter = new BinaryFormatter();
        readonly NetworkStream _network;
        readonly Socket _socket;
        private Korisnik _korisnik;
        public KlijentNit(Socket socket)
        {
            _socket = socket;
            _network = new NetworkStream(socket);
        }
        public void HandleUser()
        {
            var signal = false;
            while (!signal)
            {
                try
                {
                    var request = _formatter.Deserialize(_network) as Zahtev;
                    var response = Kontroler.Instance.ExecuteRequest(request);

                    if (request?.SistemskaOperacija == SistemskaOperacija.PrijaviSe && response.Signal)
                    {
                        _korisnik = response.Data as Korisnik;
                    }

                    _formatter.Serialize(_network, response);
                }
                catch (SocketException)
                {
                    _socket.Close();
                    signal = true;
                    SessionStorage.Instance.RemoveUser(_korisnik);
                }
                catch (IOException)
                {
                    _socket.Close();
                    signal = true;
                    SessionStorage.Instance.RemoveUser(_korisnik);
                }
                catch (SerializationException)
                {
                    _socket.Close();
                    signal = true;
                    SessionStorage.Instance.RemoveUser(_korisnik);
                }
                catch (Exception)
                {
                    _formatter.Serialize(_network, new Odgovor(false, "Doslo je do greske na serveru"));
                }
            }
        }
    }
}