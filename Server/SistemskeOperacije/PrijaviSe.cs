using Domen;
using System.Linq;
using Domen.Entiteti;

namespace Server.SistemskeOperacije
{
    internal class PrijaviSe : OpstaSistemskaOperacija
    {
        public IEntity Entity { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            var korisnik = entity as Korisnik;
            Entity = Db.Get(entity).OfType<Korisnik>().FirstOrDefault(e => e.Sifra == korisnik?.Sifra && e.Email == korisnik?.Email);
        }
    }
}
