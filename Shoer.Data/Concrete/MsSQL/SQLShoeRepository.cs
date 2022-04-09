using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Shoe;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shoer.Data.Concrete.MsSQL
{
    public class SQLShoeRepository : IShoeRepository
    {
        private List<Shoe> Shoes;
        public SQLShoeRepository()
        {
            Shoes = new List<Shoe>();
        }
        public Shoe GetById(int id)
        {
            return (GetAll().FirstOrDefault(x => x.Id == id));
        }

        public List<Shoe> GetAll()
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Shoe", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Shoe shoe = new Shoe()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    ShoeDescription = reader["ShoeDescription"].ToString(),
                    ImageText = reader["ImageText"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    Price = Convert.ToDouble(reader["Price"]),
                    Size = Convert.ToInt32(reader["Size"]),
                    Stock = Convert.ToInt32(reader["Stock"]),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"]),
                    BrandId = Convert.ToInt32(reader["BrandId"]),
                    CategoryId = Convert.ToInt32(reader["CategoryId"])
                };
                Shoes.Add(shoe);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return Shoes;
        }

        public void Create(Shoe entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("INSERT INTO Shoe (Title,ShoeDescription,ImageText,Gender,Price,Size,Stock,CreatedDate,IsDeleted,BrandId,CategoryId) VALUES (@title,@descr,@ImageText,@gender,@price,@size,@Stock,@createddate,@isdeleted,@brandid,@categoryid)", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@title", entity.Title);
            command.Parameters.AddWithValue("@descr", entity.ShoeDescription);
            command.Parameters.AddWithValue("@ImageText", entity.ImageText);
            command.Parameters.AddWithValue("@gender", entity.Gender);
            command.Parameters.AddWithValue("@price", entity.Price);
            command.Parameters.AddWithValue("@size", entity.Size);
            command.Parameters.AddWithValue("@Stock", entity.Stock);
            command.Parameters.AddWithValue("@createddate", DateTime.Now);
            command.Parameters.AddWithValue("@isdeleted", entity.IsDeleted);
            command.Parameters.AddWithValue("@brandid", entity.BrandId);
            command.Parameters.AddWithValue("@categoryid", entity.CategoryId);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Update(Shoe entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("UPDATE Shoe SET Title= @title , ShoeDescription=@descr , Gender=@gender , Price=@price , Size=@size , Stock=@Stock , CreatedDate=@createddate , IsDeleted=@isdeleted , BrandId=@brandid , CategoryId=@categoryid WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@title", entity.Title);
            command.Parameters.AddWithValue("@descr", entity.ShoeDescription);
            command.Parameters.AddWithValue("@gender", entity.Gender);
            command.Parameters.AddWithValue("@price", entity.Price);
            command.Parameters.AddWithValue("@size", entity.Size);
            command.Parameters.AddWithValue("@Stock", entity.Stock);
            command.Parameters.AddWithValue("@createddate", DateTime.Now);
            command.Parameters.AddWithValue("@isdeleted", entity.IsDeleted);
            command.Parameters.AddWithValue("@brandid", entity.BrandId);
            command.Parameters.AddWithValue("@categoryid", entity.CategoryId);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public void Delete(Shoe entity)
        {
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand("DELETE FROM Shoe WHERE Id=@Id", DatabaseConnection._connection);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
            DatabaseConnection._connection.Close();
        }

        public Shoe GetMostPopularShoe()
        {
            DatabaseConnection.Connect();
            List<ShoePopularModel> shoePopularModel = new List<ShoePopularModel>();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) (SUM(OD.Price*OD.Quantity)) AS TotalPrice,S.Id FROM OrderDetails OD
            JOIN Shoe S ON OD.ShoeId = S.Id
            WHERE OD.CreatedDate BETWEEN DATEADD(MONTH, -3, GETDATE()) AND GETDATE()
            GROUP BY S.Id
                ORDER BY TotalPrice DESC", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ShoePopularModel shoe = new ShoePopularModel()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    TotalPrice = Convert.ToDouble(reader["TotalPrice"])
                };
                shoePopularModel.Add(shoe);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            if (shoePopularModel.Count > 0)
            {
                return GetAll().FirstOrDefault(x => x.Id == shoePopularModel[0].Id);
            }
            return new Shoe() { };
        }
    }
}
