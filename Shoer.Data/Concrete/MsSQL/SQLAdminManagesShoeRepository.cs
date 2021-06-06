using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Admin_Manages_Shoe;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLAdminManagesShoeRepository : IAdminManagesShoeRepository
    {
        private List<Admin_Manages_Shoe> admin_Manages_Shoes;

        public SQLAdminManagesShoeRepository()
        {
            admin_Manages_Shoes = new List<Admin_Manages_Shoe>();
        }
        public void Create(Admin_Manages_Shoe entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Admin_Manages_Shoe(ShoeId,AdminId) " +
                                                 "VALUES (@ShoeId,@AdminId)");
            command.Parameters.AddWithValue("@ShoeId", entity.ShoeId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Admin_Manages_Shoe entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Admin_Manages_Shoe Where Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public List<Admin_Manages_Shoe> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Admin_Manages_Shoe", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Admin_Manages_Shoe admin_Manages_Shoe = new Admin_Manages_Shoe()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ShoeId = Convert.ToInt32(reader["ShoeId"]),
                    AdminId = Convert.ToInt32(reader["AdminId"])
                };
                admin_Manages_Shoes.Add(admin_Manages_Shoe);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return admin_Manages_Shoes;
        }

        public Admin_Manages_Shoe GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public void Update(Admin_Manages_Shoe entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Admin_Manages_Shoe SET BrandId = @ShoeId , AdminId = @AdminId", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@ShoeId", entity.ShoeId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }
}
