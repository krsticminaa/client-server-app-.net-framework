using System;

namespace Domen.Util
{
    [Serializable]
    public class Odgovor
    {
        public bool Signal { get; set; }
        public object Data { get; set; }

        public Odgovor(bool signal, object data = null)
        {
            Signal = signal;
            Data = data;
        }
    }
}
