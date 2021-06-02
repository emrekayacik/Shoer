using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private List<Customer> Customers;
        public SQLCustomerRepository()
        {
            Customers = new List<Customer>();
        }
        public Customer GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public List<Customer> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Customer", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Customer customer = new Customer()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"].ToString(),
                    CustomerPassword = reader["CustomerPassword"].ToString(),
                    Firstname = reader["Firstname"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"]),
                };
                Customers.Add(customer);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Customers;
        }

        public void Create(Customer entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Customer (UserName,CustomerPassword,Firstname,LastName,IsDeleted) VALUES (@UserName,@CustomerPassword,@Firstname,@LastName,'0')", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@UserName", entity.UserName);
            command.Parameters.AddWithValue("@CustomerPassword", entity.CustomerPassword);
            command.Parameters.AddWithValue("@Firstname", entity.Firstname);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Update(Customer entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Customer SET UserName= @UserName , CustomerPassword=@CustomerPassword , Firstname=@Firstname , LastName=@LastName , IsDeleted=@IsDeleted WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@UserName", entity.UserName);
            command.Parameters.AddWithValue("@CustomerPassword", entity.CustomerPassword);
            command.Parameters.AddWithValue("@Firstname", entity.Firstname);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@IsDeleted", entity.IsDeleted);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Customer entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Customer WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public Customer GetCustomerOfTheMonth()
        {
            throw new NotImplementedException();
        }
    }
}
