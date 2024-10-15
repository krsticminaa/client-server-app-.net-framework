using Domen;
using Domen.Entiteti;
using Domen.Util;
using System.Collections.Generic;

namespace Server.SistemskeOperacije
{
    internal class PretraziMarkePrenosnihRacunara : OpstaSistemskaOperacija
    {
        public List<IEntity> Entities { get; set; }
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            var kriterijumPretrage = (KriterijumPretrage) entity;
            Entities = Db.Get(new MarkaPrenosnogRacunara(), kriterijumPretrage.Tekst);
        }
    }
}
