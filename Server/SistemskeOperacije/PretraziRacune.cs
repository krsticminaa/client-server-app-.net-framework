using Domen;
using Domen.Entiteti;
using Domen.Util;
using System.Collections.Generic;

namespace Server.SistemskeOperacije
{
    internal class PretraziRacune : OpstaSistemskaOperacija
    {
        public List<IEntity> Entities { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            var kriterijumPretrage = (RacunKriterijumPretrage)entity;
            var racun = new Racun()
            {
                Korisnik = new Korisnik()
                {
                    Id = kriterijumPretrage.KorisnikId
                },
                StavkeRacuna = new List<StavkaRacuna>()
                {
                    new StavkaRacuna()
                    {
                        PrenosniRacunar = kriterijumPretrage.PrenosniRacunar
                    }
                }
            };

            Entities = Db.Get(racun, kriterijumPretrage.Tekst);
        }
    }
}
