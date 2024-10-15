using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace Domen.Entiteti
{
    [Serializable]
    public class Racun : IEntity
    {
        [Browsable(false)]
        public Korisnik Korisnik { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public double UkupanDug { get; set; }
        public string NacinPlacanja { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        public Racun()
        {
        }

        public Racun(int id, DateTime datumKreiranja, double ukupanDug, string nacinPlacanja)
        {
            Id = id;
            DatumKreiranja = datumKreiranja;
            UkupanDug = ukupanDug;
            NacinPlacanja = nacinPlacanja;
        }
        public List<StavkaRacuna> StavkeRacuna { get; set; }
        public string Dodaj()
        {
            return $"'{DatumKreiranja}', {UkupanDug}, '{NacinPlacanja}', {Korisnik.Id}";
        }

        public string Izmeni()
        {
            throw new NotImplementedException();
        }

        public string Join()
        {
            if (StavkeRacuna != null && StavkeRacuna.Count > 0 && StavkeRacuna.FirstOrDefault()?.PrenosniRacunar.Id != 0)
            {
                return
                    "INNER JOIN StavkaRacuna sr ON (sr.RacunId = r.Id) INNER JOIN PrenosniRacunar pr ON (pr.Id = sr.PrenosniRacunarId)";
            }

            return string.Empty;
        }

        public string NazivTabele() => nameof(Racun);

        public string NazivTabeleAnotacija() => $"{nameof(Racun)} r";

        public List<IEntity> VratiObjekte(SqlDataReader reader)
        {
            var entities = new List<IEntity>();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader[0]);
                var datumKreiranja = DateTime.Parse(reader[1].ToString());
                var ukupanDug = double.Parse(reader[2].ToString());
                var nacinPlacanja = reader[3].ToString();
                var entity = new Racun(id, datumKreiranja, ukupanDug, nacinPlacanja);
                entities.Add(entity);
            }
            return entities;
        }

        public string Where(string searchText = default)
        {
            var query = string.Empty;
            if (string.IsNullOrEmpty(searchText))
            {
                if (Id != 0)
                {
                    query = $"WHERE Id = {Id}";
                }


            }
            else
            {
                if (int.TryParse(searchText, out var id))
                {
                    query = $"WHERE r.Id = {id}";
                }

                if (DateTime.TryParseExact(searchText, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                {
                    query = $"WHERE CONVERT(date, DatumKreiranja) = '{date.Date}'";
                }
            }

            if (Korisnik != null && Korisnik.Id != 0)
            {
                if (string.IsNullOrEmpty(query))
                {
                    query = $"WHERE KorisnikId = {Korisnik.Id}";
                }
                else
                {
                    query += $" AND KorisnikId = {Korisnik.Id}";
                }
            }

            if (StavkeRacuna != null && StavkeRacuna.Count > 0)
            {
                var prenosniRacunarId = StavkeRacuna.FirstOrDefault()?.PrenosniRacunar.Id;
                if (prenosniRacunarId != null && prenosniRacunarId != 0)
                {
                    if (string.IsNullOrEmpty(query))
                    {
                        query = $"WHERE pr.Id = {prenosniRacunarId}";
                    }
                    else
                    {
                        query += $" AND pr.Id = {prenosniRacunarId}";
                    }
                }
            }

            return query;
        }
    }
}
