using Domen;
using Domen.Entiteti;
using System.Collections.Generic;

namespace Server.SistemskeOperacije
{
    internal class VratiListuMarki : OpstaSistemskaOperacija
    {
        public List<IEntity> Entities { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            Entities = Db.Get(new MarkaPrenosnogRacunara());
        }
    }
}
