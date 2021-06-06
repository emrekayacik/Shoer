using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLAdminManagesCategoryRepository : IAdminManagesCategoryRepository
    {

        private List<Admin_Manages_Category> Admin_Manages_Categories;

        public SQLAdminManagesCategoryRepository()
        {
            Admin_Manages_Categories = new List<Admin_Manages_Category>();
        }
        public void Create(Admin_Manages_Category entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Admin_Manages_Category(CategoryId,AdminId) " +
                                                 "VALUES (@CategoryId,@AdminId)");
            command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Admin_Manages_Category entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Admin_Manages_Brand Where Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public List<Admin_Manages_Category> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Admin_Manages_Category", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Admin_Manages_Category admin_Manages_Category = new Admin_Manages_Category()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CategoryId = Convert.ToInt32(reader["BrandId"]),
                    AdminId = Convert.ToInt32(reader["AdminId"])
                };
                Admin_Manages_Categories.Add(admin_Manages_Category);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Admin_Manages_Categories;
        }

        public Admin_Manages_Category GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public void Update(Admin_Manages_Category entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Admin_Manages_Category SET BrandId = @CategoryId , AdminId = @AdminId", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
            command.Parameters.AddWithValue("@AdminId", entity.AdminId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }
}
