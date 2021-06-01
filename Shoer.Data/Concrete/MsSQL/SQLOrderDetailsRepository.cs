using Shoer.Data.Abstract;
using Shoer.Entity.OrderDetails;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLOrderDetailsRepository : IRepository<OrderDetails>
    {
        private List<OrderDetails> OrderDetails;

        public SQLOrderDetailsRepository()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public OrderDetails GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public List<OrderDetails> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM OrderDetails", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                OrderDetails orderDetails = new OrderDetails()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ShoeId = Convert.ToInt32(reader["ShoeId"]),
                    OrderId = Convert.ToInt32(reader["OrderId"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Price = Convert.ToDouble(reader["Price"]),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                };
                OrderDetails.Add(orderDetails);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return OrderDetails;
        }

        public void Create(OrderDetails entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO OrderDetails (ShoeId,OrderId,Quantity,Price,CreatedDate) VALUES (@ShoeId,@OrderId,@Quantity,@Price,@CreatedDate)", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@ShoeId", entity.ShoeId);
            command.Parameters.AddWithValue("@OrderId", entity.OrderId);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Update(OrderDetails entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE OrderDetails SET ShoeId= @ShoeId , OrderId=@OrderId , Quantity=@Quantity , Price=@Price , CreatedDate=@CreatedDate WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@ShoeId", entity.ShoeId);
            command.Parameters.AddWithValue("@OrderId", entity.OrderId);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            command.Parameters.AddWithValue("@Id", entity.Id);

            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(OrderDetails entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Category WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }
    }
}
