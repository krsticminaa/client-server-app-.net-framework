using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.Entiteti
{
    [Serializable]
    public class PrenosniRacunarKarakteristika : IEntity
    {
        [Browsable(false)]
        public PrenosniRacunar PrenosniRacunar { get; set; }
        public Karakteristika Karakteristika { get; set; }
        public string Opis { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        public PrenosniRacunarKarakteristika()
        {
            
        }
        public PrenosniRacunarKarakteristika(int id, string opis, Karakteristika karakteristika)
        {
            Id = id;
            Opis = opis;
            Karakteristika = karakteristika;
        }

        public string Dodaj()
        {
            return $"{PrenosniRacunar.Id}, {Karakteristika.Id}, '{Opis}'";
        }

        public string Izmeni()
        {
            throw new NotImplementedException();
        }

        public string Join()
        {
            return "INNER JOIN PrenosniRacunar pr ON (pr.Id = prk.PrenosniRacunarId) INNER JOIN Karakteristika k ON (k.Id = prk.KarakteristikaId)";
        }

        public string NazivTabele() => nameof(PrenosniRacunarKarakteristika);

        public string NazivTabeleAnotacija() => $"{nameof(PrenosniRacunarKarakteristika)} prk";

        public List<IEntity> VratiObjekte(SqlDataReader reader)
        {
            var entities = new List<IEntity>();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader[0]);
                var opis = reader[1].ToString();
                var karakteristikaId = Convert.ToInt32(reader[8]);
                var nazivKarakteristike = reader[9].ToString();
                var karakteristika = new Karakteristika(karakteristikaId, nazivKarakteristike);
                var entity = new PrenosniRacunarKarakteristika(id, opis, karakteristika);

                entities.Add(entity);
            }
            return entities;
        }

        public string Where(string searchText = default)
        {

            return $"WHERE pr.Id = {PrenosniRacunar.Id}";
        }
    }
}
