using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen.Entiteti
{
    [Serializable]
    public class Korisnik : IEntity
    {
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public string Sifra { get; set; }
        public int Id { get; set; }
        public Korisnik()
        {
            
        }

        public Korisnik(string email, string sifra)
        {
            Email = email;
            Sifra = sifra;
        }

        public Korisnik(int id, string imePrezime, string email, string sifra)
        {
            Id = id;
            ImePrezime = imePrezime;
            Email = email;
            Sifra = sifra;
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

        public string NazivTabele() => nameof(Korisnik);

        public string NazivTabeleAnotacija() => $"{nameof(Korisnik)} k";

        public List<IEntity> VratiObjekte(SqlDataReader reader)
        {
            var entities = new List<IEntity>();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader[0]);
                var imePrezime = reader[1].ToString();
                var email = reader[2].ToString();
                var sifra = reader[3].ToString();
                var entity = new Korisnik(id, imePrezime, email, sifra);
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
            return Email;
        }
    }
}
