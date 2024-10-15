using System.Configuration;
using System.Data.SqlClient;

namespace Broker
{
    internal class DbConnection
    {
        private readonly SqlConnection _connection = 
            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        
        private SqlTransaction _transaction;
        public void OpenConnection() => _connection?.Open();
        public void CloseConnection() => _connection?.Close();
        public void BeginTransaction() => _transaction = _connection.BeginTransaction();
        public void Commit() => _transaction?.Commit();
        public void Rollback() => _transaction.Rollback();
        public SqlCommand CreateCommand(string cmbText) => new SqlCommand(cmbText, _connection, _transaction);
    }
}
