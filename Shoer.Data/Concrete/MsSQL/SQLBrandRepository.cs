using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Brand;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLBrandRepository : IBrandRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        private List<Brand> Brands;

        public SQLBrandRepository()
        {
            _databaseConnection = new DatabaseConnection();
            Brands = new List<Brand>();
        }
        public Brand GetById(int id)
        {
            _databaseConnection.Connect();
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            _databaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Brand", _databaseConnection._connection);
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
            _databaseConnection._connection.Close();
            return Brands;
        }

        public void Create(Brand entity)
        {
            _databaseConnection.Connect();
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            _databaseConnection.Connect();
            throw new NotImplementedException();
        }

        public void Delete(Brand entity)
        {
            _databaseConnection.Connect();
            throw new NotImplementedException();
        }

        public Brand GetMostPopularBrand()
        {
            _databaseConnection.Connect();
            throw new NotImplementedException();
        }
    }
}
