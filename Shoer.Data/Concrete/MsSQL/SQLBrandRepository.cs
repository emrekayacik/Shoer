using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Brand;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLBrandRepository : IBrandRepository
    {
        private List<Brand> Brands;

        public SQLBrandRepository()
        {
            Brands = new List<Brand>();
        }
        public Brand GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public List<Brand> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Brand", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Brand brand = new Brand()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    BrandName = reader["BrandName"].ToString()
                };
                Brands.Add(brand);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Brands;
        }

        public void Create(Brand entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Brand (BrandName) VALUES (@BrandName)", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@BrandName", entity.BrandName);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Update(Brand entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Brand SET BrandName= @BrandName WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@BrandName", entity.BrandName);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Brand entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Brand WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public Brand GetMostPopularBrand()
        {
            DatabaseConnection.Connect();
            throw new NotImplementedException();
        }
    }
}
