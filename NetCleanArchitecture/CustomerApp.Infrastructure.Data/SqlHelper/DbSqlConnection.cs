

namespace CustomerApp.Infrastructure.Data.SqlHelper
{
    public class DbSqlConnection : IDbSqlConnection
    {
        public DbSqlConnection(string conn)
        {
            ConnectionString = conn; 
        }

        public string ConnectionString { get; private set; }

        public void SetConnectionString(string conn)
        {
            ConnectionString = conn;
        }
    }
}
