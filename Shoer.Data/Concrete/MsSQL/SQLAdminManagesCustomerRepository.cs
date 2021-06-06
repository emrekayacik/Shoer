using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Admin_Manages_Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLAdminManagesCustomerRepository : IAdminManagesCustomerRepository
    {

        private List<Admin_Manages_Customer> Admin_Manages_Customers;
        
        public SQLAdminManagesCustomerRepository()
        {
            Admin_Manages_Customers = new List<Admin_Manages_Customer>();
        }
        public void Create(Admin_Manages_Customer entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Admin_Manages_Customer(CustomerId,AdminId) " +
                                                 "VALUES (@CustomerId,@AdminId)");
            command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Admin_Manages_Customer entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Admin_Manages_Customer Where Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public List<Admin_Manages_Customer> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Admin_Manages_Customer", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Admin_Manages_Customer admin_Manages_Customer = new Admin_Manages_Customer()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    AdminId = Convert.ToInt32(reader["AdminId"])
                };
                Admin_Manages_Customers.Add(admin_Manages_Customer);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Admin_Manages_Customers;
        }

        public Admin_Manages_Customer GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public void Update(Admin_Manages_Customer entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Admin_Manages_Customer SET BrandId = @CustomerId , AdminId = @AdminId", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@CategoryId", entity.CustomerId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }
}
