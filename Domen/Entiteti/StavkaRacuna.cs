using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.Entiteti
{
    [Serializable]
    public class StavkaRacuna : IEntity
    {
        [Browsable(false)]
        public Racun Racun { get; set; }
        public int Kolicina { get; set; }
        public double UkupnaNaknada { get; set; }
        public double Cena { get; set; }
        public PrenosniRacunar PrenosniRacunar { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        public StavkaRacuna()
        {
            
        }
        public StavkaRacuna(int id, Racun racun, int kolicina, double ukupnaNaknada, double cena, PrenosniRacunar prenosniRacunar)
        {
            Id = id;
            Racun = racun;
            Kolicina = kolicina;
            UkupnaNaknada = ukupnaNaknada;
            Cena = cena;
            PrenosniRacunar = prenosniRacunar;
        }

        public string Dodaj()
        {
            return $"{Racun.Id}, {Kolicina}, {UkupnaNaknada}, {Cena}, {PrenosniRacunar.Id}";
        }

        public string Izmeni()
        {
            throw new NotImplementedException();
        }

        public string Join()
        {
            return "INNER JOIN PrenosniRacunar pr ON (pr.Id = sr.PrenosniRacunarId)";
        }

        public string NazivTabele() => nameof(StavkaRacuna);

        public string NazivTabeleAnotacija() => $"{nameof(StavkaRacuna)} sr";

        public List<IEntity> VratiObjekte(SqlDataReader reader)
        {
            var entities = new List<IEntity>();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader[0]);
                var racunId = Convert.ToInt32(reader[1]);
                var kolicina = Convert.ToInt32(reader[2]);
                var ukupnaNaknada = double.Parse(reader[3].ToString());
                var cena = double.Parse(reader[4].ToString());
                var prenosniRacunarId = Convert.ToInt32(reader[5]);
                var nazivPrenosnogRacunara = reader[7].ToString();
                var prenosniRacunar = new PrenosniRacunar(prenosniRacunarId, nazivPrenosnogRacunara);
                var racun = new Racun() { Id = racunId };
                var entity = new StavkaRacuna(id, racun, kolicina, ukupnaNaknada, cena, prenosniRacunar);
                entities.Add(entity);
            }
            return entities;
        }

        public string Where(string searchText = default)
        {
            return $"WHERE sr.RacunId = {Racun.Id}";
        }
    }
}
