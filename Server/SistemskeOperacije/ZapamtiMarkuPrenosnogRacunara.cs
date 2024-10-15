using Domen;
using Domen.Entiteti;
using System.Linq;

namespace Server.SistemskeOperacije
{
    internal class ZapamtiMarkuPrenosnogRacunara : OpstaSistemskaOperacija
    {
        public bool ExistSame { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            var marka = entity as MarkaPrenosnogRacunara;

            var marke = Db.Get(entity).OfType<MarkaPrenosnogRacunara>().ToList();

            if (marke.Any(e => e.Naziv.ToLower() == marka.Naziv.ToLower()))
            {
                ExistSame = true;
                return;
            }

            Db.Add(marka);
        }
    }
}
