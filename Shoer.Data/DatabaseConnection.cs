using System.Data;
using System.Data.SqlClient;

namespace Shoer.Data
{
    public static class DatabaseConnection
    {
        public static SqlConnection _connection = new SqlConnection(@"server=DESKTOP-FSM7F8K;initial catalog=ShoeECommerce;integrated security=true");
        //public static SqlConnection _connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=ShoeECommerce;integrated security=true");

        public static void Connect()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
