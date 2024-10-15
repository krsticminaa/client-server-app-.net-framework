using Domen;
using System.Linq;

namespace Server.SistemskeOperacije
{
    internal class VratiMarkuPrenosnogRacunara : OpstaSistemskaOperacija
    {
        public IEntity Entity { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            Entity = Db.Get(entity).FirstOrDefault();
        }
    }
}
