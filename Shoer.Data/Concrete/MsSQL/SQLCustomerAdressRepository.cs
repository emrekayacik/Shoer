using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.CustomerAdress;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLCustomerAdressRepository : ICustomerAdressRepository
    {

        private List<CustomerAdress> CustomerAdresses;

        public SQLCustomerAdressRepository()
        {
            CustomerAdresses = new List<CustomerAdress>();
        }
        public void Create(CustomerAdress entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO CustomerAdress(City,Street,PostalCode,ApartmentNo,FlatNo,CustomerId) VALUES (@City,@Street,@PostalCode,@ApartmentNo,@FlatNo,@CustomerId) ", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@City", entity.City);
            command.Parameters.AddWithValue("@Street", entity.Street);
            command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
            command.Parameters.AddWithValue("@ApartmentNo", entity.ApartmentNo);
            command.Parameters.AddWithValue("@FlatNo", entity.FlatNo);
            command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();

        }

        public void Delete(CustomerAdress entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM CustomerAdress Where Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public List<CustomerAdress> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM CustomerAdress", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CustomerAdress customerAdress = new CustomerAdress()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    City = Convert.ToString(reader["City"]),
                    Street = Convert.ToString(reader["Street"]),
                    PostalCode = Convert.ToInt32(reader["PostalCode"]),
                    ApartmentNo = Convert.ToInt32(reader["ApartmentNo"]),
                    FlatNo = Convert.ToInt32(reader["FlatNo"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                };
                CustomerAdresses.Add(customerAdress);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return CustomerAdresses;
        }

        public CustomerAdress GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public void Update(CustomerAdress entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE CustomerAdress SET City = @City, Street = @Street, PostalCode=@PostalCode, ApartmentNo = @ApartmentNo, FlatNo = @FlatNo, CustomerId = @CustomerId ", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@City", entity.City);
            command.Parameters.AddWithValue("@Street", entity.Street);
            command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
            command.Parameters.AddWithValue("@ApartmentNo", entity.ApartmentNo);
            command.Parameters.AddWithValue("@FlatNo", entity.FlatNo);
            command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();


        }
    }
}
