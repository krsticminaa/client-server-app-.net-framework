using Domen;
using Domen.Entiteti;
using System.Linq;

namespace Server.SistemskeOperacije
{
    internal class DodajPrenosniRacunar : OpstaSistemskaOperacija
    {
        public bool ExistSame { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            var prenosniRacunar = (PrenosniRacunar) entity;

            var prenosniRacunari = Db.Get(entity).OfType<PrenosniRacunar>().ToList();

            if (prenosniRacunari.Any(e => e.Naziv.ToLower() == prenosniRacunar.Naziv.ToLower()))
            {
                ExistSame = true;
                return;
            }

            prenosniRacunar.Id = Db.Add(prenosniRacunar);
            foreach (var prenosniRacunarKarakteristika in prenosniRacunar.Karakteristike)
            {
                prenosniRacunarKarakteristika.PrenosniRacunar = prenosniRacunar;
                Db.Add(prenosniRacunarKarakteristika);
            }
        }
    }
}
