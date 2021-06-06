using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Admin_Manages_Orders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLAdminManagesOrdersRepository : IAdminManagesOrdersRepository
    {

        private List<Admin_Manages_Orders> Admin_Manages_Orderss;
        
        public SQLAdminManagesOrdersRepository ()
        {
            Admin_Manages_Orderss = new List<Admin_Manages_Orders>();
        }
        public void Create(Admin_Manages_Orders entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Admin_Manages_Orders(StatusEditDate,OrderId,AdminId) " +
                                                 "VALUES (@StatusEditDate,@OrderId,@AdminId)");
            command.Parameters.AddWithValue("@StatusEditDate", entity.StatusEditDate);
            command.Parameters.AddWithValue("@BrandId", entity.OrderId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Admin_Manages_Orders entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Admin_Manages_Orders Where Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public List<Admin_Manages_Orders> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Admin_Manages_Orders", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Admin_Manages_Orders admin_Manages_Orders = new Admin_Manages_Orders()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    StatusEditDate = Convert.ToDateTime(reader["StatusEditDate"]),
                    OrderId = Convert.ToInt32(reader["OrderId"]),
                    AdminId = Convert.ToInt32(reader["AdminId"])
                };
                Admin_Manages_Orderss.Add(admin_Manages_Orders);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Admin_Manages_Orderss;
        }

        public Admin_Manages_Orders GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public void Update(Admin_Manages_Orders entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Admin_Manages_Brand SET StatusEditDate = @StatusEditDate, OrderId = @BrandId , AdminId = @AdminId", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@StatusEditDate", entity.StatusEditDate);
            command.Parameters.AddWithValue("@OrderId", entity.OrderId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }


    
       
    
}
