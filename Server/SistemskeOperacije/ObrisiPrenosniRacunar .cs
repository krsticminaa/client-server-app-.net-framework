using Domen;

namespace Server.SistemskeOperacije
{
    internal class ObrisiPrenosniRacunar : OpstaSistemskaOperacija
    {
        protected override void ExecuteConcreteOperation(IEntity entity)
        {
            Db.Delete(entity);
        }
    }
}
