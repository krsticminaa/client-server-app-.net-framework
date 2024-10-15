using Domen;
using Domen.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    internal class UcitajRacun : OpstaSistemskaOperacija
    {
        public IEntity Entity { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            var racun = Db.Get(entity).OfType<Racun>().FirstOrDefault();
            if (racun == null)
            {
                return;
            }

            racun.StavkeRacuna = Db.Get(new StavkaRacuna()
                    { Racun = racun })
                .OfType<StavkaRacuna>()
                .ToList();
            Entity = racun;
        }
    }
}
