using Domen;
using Domen.Entiteti;
using System;
using System.Collections.Generic;

namespace Broker
{
    public class BrokerBazePodataka
    {
        private readonly DbConnection _connection = new DbConnection();

        public int Add(IEntity entity)
        {
            var query = _connection.CreateCommand($"insert into {entity.NazivTabele()} values ({entity.Dodaj()});SELECT SCOPE_IDENTITY();");

            if (entity is PrenosniRacunarKarakteristika)
            {
                if (query.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Greska prilikom upisa u bazu");
                }

                return 0;
            }

            var id = Convert.ToInt32(query.ExecuteScalar());
            return id;
        }

        public void Update(IEntity entity)
        {
            var query = _connection.CreateCommand($"UPDATE {entity.NazivTabele()} SET {entity.Izmeni()} WHERE Id = {entity.Id}");
            
            if (query.ExecuteNonQuery() == 0)
            {
                throw new Exception("Greska prilikom upisa u bazu");
            }
        }

        public List<IEntity> Get(IEntity entity, string searchText = default)
        {
            var query = 
                _connection.CreateCommand($"select * from {entity.NazivTabeleAnotacija()} {entity.Join()} {entity.Where(searchText)}");
            
            using (var reader = query.ExecuteReader())
            {
                return entity.VratiObjekte(reader);
            }





        }
        public void Delete(IEntity entity)
        {
            var query = _connection.CreateCommand($"delete from {entity.NazivTabele()} WHERE Id = {entity.Id}");
            query.ExecuteNonQuery();
        }
        public void OpenConnection() => _connection.OpenConnection();
        public void CloseConnection() => _connection.CloseConnection();
        public void BeginTransaction() => _connection.BeginTransaction();
        public void Commit() => _connection.Commit();
        public void RollBack() => _connection.Rollback();
    }
}







//public List<KorisnikRacun> GetKorisniciIRacun()
//{
//    OpenConnection();
//    var query =
//        _connection.CreateCommand($"SELECT k.Id, ImePrezime, COUNT(r.Id) FROM [dbo].[Korisnik] k LEFT JOIN Racun r ON (r.KorisnikId = k.Id) GROUP BY k.Id,ImePrezime");

//    var korisnici = new List<KorisnikRacun>();
//    using (var reader = query.ExecuteReader())
//    {
//        while (reader.Read())
//        {
//            var korisnik = new KorisnikRacun();
//            korisnik.KorisnikId = reader.GetInt32(0);
//            korisnik.ImePrezime = reader.GetString(1);
//            korisnik.BrojKreiranihRacuna = reader.GetInt32(2);
//            korisnici.Add(korisnik);
//        }
//    }
//    CloseConnection();

//    return korisnici;
//}

