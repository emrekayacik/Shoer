using System.Data;
using System.Data.SqlClient;

namespace Shoer.Data
{
    public class DatabaseConnection
    {
        public SqlConnection _connection;
        public DatabaseConnection()
        {
            _connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=ShoeECommerce;integrated security=true");
        }
        public void Connect()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
