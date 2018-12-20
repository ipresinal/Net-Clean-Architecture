

namespace CustomerApp.Infrastructure.Data.SqlHelper
{
    public interface IDbSqlConnection
    {
        string ConnectionString { get; }
        void SetConnectionString(string conn);
    }
}
