using System;
using Broker;
using Domen;

namespace Server.SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected BrokerBazePodataka Db = new BrokerBazePodataka();
        protected abstract void ExecuteConcreteOperation(IEntity entity);
        public void Execute(IEntity entity)
        {
            try
            {
                Db.OpenConnection();
                Db.BeginTransaction();
                ExecuteConcreteOperation(entity);
                Db.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Db.RollBack();
                throw;
            }
            finally
            {
                Db.CloseConnection();
            }
        }
    }
}
