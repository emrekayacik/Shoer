using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Admin_Manages_brand;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLAdminManagesBrandRepository : IAdminManagesBrandRepository
    {

        private List<Admin_Manages_Brand> Admin_Manages_Brands;

        public SQLAdminManagesBrandRepository()
        {
            Admin_Manages_Brands = new List<Admin_Manages_Brand>();

        }
        public void Create(Admin_Manages_Brand entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Admin_Manages_Brand(BrandId,AdminId) " +
                                                 "VALUES (@BrandId,@AdminId)");
            command.Parameters.AddWithValue("@BrandId", entity.BrandId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Admin_Manages_Brand entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Admin_Manages_Brand Where Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public List<Admin_Manages_Brand> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Admin_Manages_Brand", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Admin_Manages_Brand admin_Manages_Brand = new Admin_Manages_Brand()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    BrandId = Convert.ToInt32(reader["BrandId"]),
                    AdminId = Convert.ToInt32(reader["AdminId"])
                };
                Admin_Manages_Brands.Add(admin_Manages_Brand);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Admin_Manages_Brands;
        }

        public Admin_Manages_Brand GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public void Update(Admin_Manages_Brand entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Admin_Manages_Brand SET BrandId = @BrandId , AdminId = @AdminId", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@BrandId", entity.BrandId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }
}
