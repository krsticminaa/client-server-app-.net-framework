using Domen;
using Domen.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Klijent
{
    internal class Communication
    {
        Socket _socket;
        NetworkStream _stream;
        readonly BinaryFormatter _formatter = new BinaryFormatter();

        private static Communication _instance;
        private Communication()
        {
            Connect();
        }

        public static Communication Instance => _instance ?? (_instance = new Communication());

        public bool Connect()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Connect("localhost", 9090);
                _stream = new NetworkStream(_socket);
                return true;
            }
            catch (SocketException)
            {
                return false;

            }
        }

        public Odgovor SendRequest(SistemskaOperacija sistemskaOperacija, IEntity entity)
        {
            try
            {
                _formatter.Serialize(_stream, new Zahtev(sistemskaOperacija, entity));
                return (Odgovor)_formatter.Deserialize(_stream);
            }
            catch (SocketException)
            {
                _socket.Close();
                MessageBox.Show(@"Doslo je do greske na serveru! Pokusajte ponovo!");
                Environment.Exit(1);
                return new Odgovor(false, "");
            }
            catch (IOException)
            {
                _socket.Close();
                MessageBox.Show(@"Doslo je do greske na serveru! Pokusajte ponovo");
                Environment.Exit(1);
                return new Odgovor(false, "");
            }
            catch (SerializationException)
            {
                _socket.Close();
                MessageBox.Show(@"Doslo je do greske na serveru! Pokusajte ponovo");
                Environment.Exit(1);
                return new Odgovor(false, "");
            }
        }


        public List<T> GetEntities<T>(SistemskaOperacija sistemskaOperacija, T entity) where T : IEntity
        {
            var response = SendRequest(sistemskaOperacija, entity);
            //List<IEntity> 
            
            if (response.Signal)
            {
                return ((List<IEntity>)response.Data).OfType<T>().ToList();
            }

            return default;
        }
    }
}
