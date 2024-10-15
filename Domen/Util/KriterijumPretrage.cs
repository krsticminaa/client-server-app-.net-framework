using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen.Util
{
    [Serializable]
    public class KriterijumPretrage : IEntity
    {
        public KriterijumPretrage(string tekst)
        {
            Tekst = tekst;
        }

        public string Tekst { get; set; }
        public int Id { get; set; }
        public string NazivTabele()
        {
            throw new NotImplementedException();
        }

        public string NazivTabeleAnotacija()
        {
            throw new NotImplementedException();
        }

        public string Dodaj()
        {
            throw new NotImplementedException();
        }

        public string Izmeni()
        {
            throw new NotImplementedException();
        }

        public string Join()
        {
            throw new NotImplementedException();
        }

        public string Where(string searchText = default)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> VratiObjekte(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
