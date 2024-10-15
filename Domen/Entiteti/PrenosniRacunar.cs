using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.Entiteti
{
    [Serializable]
    public class PrenosniRacunar : IEntity
    {
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public int BrojNaStanju { get; set; }
        public MarkaPrenosnogRacunara MarkaPrenosnogRacunara { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        public List<PrenosniRacunarKarakteristika> Karakteristike { get; set; }
        public PrenosniRacunar()
        {
            
        }
        public PrenosniRacunar(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }

        public PrenosniRacunar(int id, string naziv, double cena, int brojNaStanju, MarkaPrenosnogRacunara marka)
        {
            Id = id;
            Naziv = naziv;
            Cena = cena;
            BrojNaStanju = brojNaStanju;
            MarkaPrenosnogRacunara = marka;
        }

        public string Dodaj()
        {
            return $"'{Naziv}', {Cena}, {BrojNaStanju}, {MarkaPrenosnogRacunara.Id}";
        }

        public string Izmeni()
        {
            return $"BrojNaStanju = {BrojNaStanju}";
        }

        public string Join()
        {
            return "INNER JOIN MarkaPrenosnogRacunara mpr ON (pr.MarkaId = mpr.Id)";
        }

        public string NazivTabele() => nameof(PrenosniRacunar);

        public string NazivTabeleAnotacija() => $"{nameof(PrenosniRacunar)} pr";

        public List<IEntity> VratiObjekte(SqlDataReader reader)
        {
            var entities = new List<IEntity>();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader[0]);
                var naziv = reader[1].ToString();
                var cena = double.Parse(reader[2].ToString());
                var brojNaStanju = int.Parse(reader[3].ToString());
                var markaId = int.Parse(reader[3].ToString());
                var nazivMarke = reader[6].ToString();

                var marka = new MarkaPrenosnogRacunara(markaId, nazivMarke);
                var entity = new PrenosniRacunar(id, naziv, cena, brojNaStanju, marka);
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
                    return $"where pr.Id = {Id}";
                }
            }
            else
            {
                return $"WHERE LOWER(pr.Naziv) LIKE '%{searchText}%' OR LOWER(mpr.Naziv) LIKE '%{searchText}%'";
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
