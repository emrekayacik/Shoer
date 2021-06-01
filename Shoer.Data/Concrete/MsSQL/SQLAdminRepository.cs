using Shoer.Data.Abstract;
using Shoer.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLAdminRepository : IRepository<Admin>
    {
        private List<Admin> Admins;

        public SQLAdminRepository()
        {
            Admins = new List<Admin>();
        }
        public Admin GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));

        }

        public List<Admin> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Admins", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Admin admin = new Admin()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"].ToString(),
                    AdminPassword = reader["AdminPassword"].ToString()
                };
                Admins.Add(admin);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Admins;
        }

        public void Create(Admin entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Admins (UserName,AdminPassword) VALUES (@UserName,@AdminPassword)", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@UserName", entity.UserName);
            command.Parameters.AddWithValue("@AdminPassword", entity.AdminPassword);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Update(Admin entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Admins SET UserName= @UserName , AdminPassword = @AdminPassword WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@UserName", entity.UserName);
            command.Parameters.AddWithValue("@AdminPassword", entity.AdminPassword);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Admin entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Admins WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }
}
