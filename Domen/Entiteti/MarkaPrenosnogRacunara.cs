using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.Entiteti
{
    [Serializable]
    public class MarkaPrenosnogRacunara : IEntity
    {
        public string Naziv { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        public MarkaPrenosnogRacunara()
        {
            
        }

        public MarkaPrenosnogRacunara(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }

        public string Dodaj()
        {
            return $"'{Naziv}'";
        }

        public string Izmeni()
        {
            throw new NotImplementedException();
        }

        public string Join()
        {
            return string.Empty;
        }

        public string NazivTabele() => nameof(MarkaPrenosnogRacunara);

        public string NazivTabeleAnotacija() => $"{nameof(MarkaPrenosnogRacunara)} mpr";

        public List<IEntity> VratiObjekte(SqlDataReader reader)
        {
            var entities = new List<IEntity>();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader[0]);
                var naziv = reader[1].ToString();
                var entity = new MarkaPrenosnogRacunara(id, naziv);
                entities.Add(entity);
            }

            return entities;
        }

        public string Where(string searchText = default)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                if (Id != 0)
                {
                    return $"WHERE Id = {Id}";
                }
            }
            else
            {
                return $"WHERE LOWER(mpr.Naziv) LIKE '%{searchText}%'";
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
