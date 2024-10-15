using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen.Entiteti
{
    [Serializable]
    public class Karakteristika : IEntity
    {
        public string Naziv { get; set; }
        public int Id { get; set; }
        public Karakteristika()
        {
            
        }
        public Karakteristika(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
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
            return string.Empty;
        }

        public string NazivTabele() => nameof(Karakteristika);

        public string NazivTabeleAnotacija() => $"{nameof(Karakteristika)} ka";

        public List<IEntity> VratiObjekte(SqlDataReader reader)
        {
            var entities = new List<IEntity>();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader[0]);
                var naziv = reader[1].ToString();
                var entity = new Karakteristika(id, naziv);
                entities.Add(entity);
            }
            return entities;
        }

        public string Where(string searchText = default)
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
