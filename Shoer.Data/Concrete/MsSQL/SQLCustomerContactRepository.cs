using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.CustomerContact;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLCustomerContactRepository : ICustomerContactRepository
    {

        private List<CustomerContact> CustomerContacts;

        public SQLCustomerContactRepository()
        {
            CustomerContacts = new List<CustomerContact>();
        }
        public void Create(CustomerContact entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO CustomerContact(Email,PhoneNo,CustomerId) VALUES(@Email,@PhoneNo,@CustomerId) ", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@PhoneNo", entity.PhoneNo);
            command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(CustomerContact entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM CustomerContact Where Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public List<CustomerContact> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM CustomerContact", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CustomerContact customerContact = new CustomerContact()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Email = Convert.ToString(reader["Email"]),
                    PhoneNo = Convert.ToInt32(reader["PhoneNo"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                };
                CustomerContacts.Add(customerContact);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return CustomerContacts;
        }

        public CustomerContact GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public void Update(CustomerContact entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE CustomerContact SET Email = @Email, PhoneNo=@PhoneNo, CustomerId = @CustomerId ", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@PhoneNo", entity.PhoneNo);
            command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }
}
