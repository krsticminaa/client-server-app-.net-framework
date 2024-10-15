using System;

namespace Domen.Util
{
    [Serializable]
    public class Zahtev
    {
        public SistemskaOperacija SistemskaOperacija { get; set; }
        public IEntity Entity { get; set; }

        public Zahtev(SistemskaOperacija sistemskaOperacija, IEntity entity)
        {
            SistemskaOperacija = sistemskaOperacija;
            Entity = entity;
        }
    }
}
