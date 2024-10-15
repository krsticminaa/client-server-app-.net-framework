using Domen;
using Domen.Entiteti;
using System.Collections.Generic;

namespace Server.SistemskeOperacije
{
    internal class VratiListuRacuna : OpstaSistemskaOperacija
    {
        public List<IEntity> Entities { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            Entities = Db.Get(new Racun());
        }
    }
}
