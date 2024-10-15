using Domen;
using Domen.Entiteti;
using System.Linq;

namespace Server.SistemskeOperacije
{
    internal class UcitajPrenosniRacunar : OpstaSistemskaOperacija
    {
        public IEntity Entity { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            var prenosniRacunar = Db.Get(entity).OfType<PrenosniRacunar>().FirstOrDefault();
            if (prenosniRacunar == null)
            {
                return;
            }

            prenosniRacunar.Karakteristike = Db.Get(new PrenosniRacunarKarakteristika()
                    { PrenosniRacunar = prenosniRacunar })
                .OfType<PrenosniRacunarKarakteristika>()
                .ToList();

            Entity = prenosniRacunar;
        }
    }
}
