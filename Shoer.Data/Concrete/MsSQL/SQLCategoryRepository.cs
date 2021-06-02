using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Category;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private List<Category> Categories;

        public SQLCategoryRepository()
        {
            Categories = new List<Category>();
        }
        public Category GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public List<Category> GetAll()
        {
            Categories.Clear();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Category", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Category Category = new Category()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CategoryName = reader["CategoryName"].ToString()
                };
                Categories.Add(Category);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Categories;
        }

        public void Create(Category entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Category (CategoryName) VALUES (@CategoryName)", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Update(Category entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Category SET CategoryName= @CategoryName WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Category entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Category WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public Category GetMostPopularCategory()
        {
            throw new System.NotImplementedException();
        }
    }
}
