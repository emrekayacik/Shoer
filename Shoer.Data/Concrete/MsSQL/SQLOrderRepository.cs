using Shoer.Data.Abstract;
using Shoer.Entity.Order;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLOrderRepository : IRepository<Order>
    {
        private List<Order> Orders;

        public SQLOrderRepository()
        {
            Orders = new List<Order>();
        }
        public Order GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public List<Order> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE IsDeleted='0'", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Order order = new Order()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    OrderStatus = reader["OrderStatus"].ToString(),
                    OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"]),
                    TotalPayment = Convert.ToDouble(reader["TotalPayment"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"])
                };
                Orders.Add(order);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Orders;
        }

        public void Create(Order entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Orders (OrderStatus,OrderDate,TotalPayment,IsDeleted,CustomerId) VALUES (@OrderStatus,@OrderDate,@TotalPayment,@IsDeleted,@CustomerId)", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@OrderStatus", entity.OrderStatus);
            command.Parameters.AddWithValue("@OrderDate", entity.OrderDate);
            command.Parameters.AddWithValue("@TotalPayment", entity.TotalPayment);
            command.Parameters.AddWithValue("@IsDeleted", entity.IsDeleted);
            command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Update(Order entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Orders SET OrderStatus= @title , OrderDate=@descr , TotalPayment=@gender , IsDeleted=@price , CustomerId=@size WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@OrderStatus", entity.OrderStatus);
            command.Parameters.AddWithValue("@OrderDate", entity.OrderDate);
            command.Parameters.AddWithValue("@TotalPayment", entity.TotalPayment);
            command.Parameters.AddWithValue("@IsDeleted", entity.IsDeleted);
            command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
            command.Parameters.AddWithValue("@Id", entity.Id);

            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Order entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("Update Orders SET IsDeleted='1' WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }
}
