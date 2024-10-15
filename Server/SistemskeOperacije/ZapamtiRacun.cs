using System;
using System.Linq;
using Domen;
using Domen.Entiteti;

namespace Server.SistemskeOperacije
{
    internal class ZapamtiRacun : OpstaSistemskaOperacija
    {
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            var racun = (Racun)entity;
            racun.Id = Db.Add(racun);
            foreach (var stavkaRacuna in racun.StavkeRacuna)
            {
                var racunar = Db.Get(stavkaRacuna.PrenosniRacunar).FirstOrDefault() as PrenosniRacunar;

                if (stavkaRacuna.Kolicina > racunar?.BrojNaStanju)
                {
                    throw new Exception("Ne mozete dodati zato sto nemamo dovoljno na stanju!");
                }

                stavkaRacuna.Racun = racun;
                Db.Add(stavkaRacuna);
                Db.Update(stavkaRacuna.PrenosniRacunar);
            }
        }
    }
}
