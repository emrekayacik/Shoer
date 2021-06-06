using Shoer.Models;
using System;
using System.Data.SqlClient;

namespace Shoer.Data.Abstract
{
    public class InterestingQueryRepository
    {
        public MostLeastSoldCategory3MonthModel GetMostSoldCategory3Month()
        {
            MostLeastSoldCategory3MonthModel category = new MostLeastSoldCategory3MonthModel();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) (SUM(OD.Quantity*OD.Price)) AS Total,C.CategoryName,C.Id FROM OrderDetails OD
            JOIN Shoe S ON OD.ShoeId = S.Id
            JOIN Category C ON S.CategoryId = C.Id
            WHERE OD.CreatedDate BETWEEN DATEADD(MONTH, -3, GETDATE()) AND GETDATE()
            GROUP BY C.CategoryName, C.Id
                ORDER BY Total DESC; ", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = reader["CategoryName"].ToString();
                category.Total = Convert.ToDouble(reader["Total"]);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return category;
        }
        public MostLeastSoldCategory3MonthModel GetLeastSoldCategory3Month()
        {
            MostLeastSoldCategory3MonthModel category = new MostLeastSoldCategory3MonthModel();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) (SUM(OD.Quantity*OD.Price)) AS Total,C.CategoryName,C.Id FROM OrderDetails OD
                    JOIN Shoe S ON OD.ShoeId=S.Id
                    JOIN Category C ON S.CategoryId = C.Id
                    WHERE OD.CreatedDate BETWEEN DATEADD(MONTH, -3, GETDATE()) AND GETDATE()
                GROUP BY C.CategoryName,C.Id
                    ORDER BY Total ASC;", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = reader["CategoryName"].ToString();
                category.Total = Convert.ToDouble(reader["Total"]);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return category;
        }

        public MostLeastSoldShoe3Month GetMostSoldShoe3Month()
        {
            MostLeastSoldShoe3Month shoe = new MostLeastSoldShoe3Month();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) (SUM(OD.Price*OD.Quantity)) AS TotalPrice,S.Title,S.Id FROM OrderDetails OD
JOIN Shoe S ON OD.ShoeId = S.Id
WHERE OD.CreatedDate BETWEEN DATEADD(MONTH,-3,GETDATE()) AND GETDATE()
GROUP BY S.Title,S.Id
ORDER BY TotalPrice DESC;", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                shoe.Id = Convert.ToInt32(reader["Id"]);
                shoe.Title = reader["Title"].ToString();
                shoe.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return shoe;
        }
        public MostLeastSoldShoe3Month GetLeastSoldShoe3Month()
        {
            MostLeastSoldShoe3Month shoe = new MostLeastSoldShoe3Month();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) (SUM(OD.Price*OD.Quantity)) AS TotalPrice,S.Title,S.Id FROM OrderDetails OD
JOIN Shoe S ON OD.ShoeId = S.Id
WHERE OD.CreatedDate BETWEEN DATEADD(MONTH,-3,GETDATE()) AND GETDATE()
GROUP BY S.Title,S.Id
ORDER BY TotalPrice ASC;", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                shoe.Id = Convert.ToInt32(reader["Id"]);
                shoe.Title = reader["Title"].ToString();
                shoe.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return shoe;
        }

        public BiggestIncomeShoeModel GetBiggestIncomeShoe()
        {
            BiggestIncomeShoeModel shoe = new BiggestIncomeShoeModel();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) S.Title,(SUM(OD.Quantity*OD.Price)) AS Total,S.Id
FROM OrderDetails OD
JOIN Shoe S ON OD.ShoeId = S.Id
GROUP BY S.Title,S.Id
ORDER BY Total DESC;", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                shoe.Id = Convert.ToInt32(reader["Id"]);
                shoe.Title = reader["Title"].ToString();
                shoe.Total = Convert.ToDouble(reader["Total"]);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return shoe;
        }
        public MostLeastSoldBrandThisMonth GetMostSoldBrand()
        {
            MostLeastSoldBrandThisMonth brand = new MostLeastSoldBrandThisMonth();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) (SUM(OD.Price*OD.Quantity)) AS Total,B.BrandName,B.Id FROM OrderDetails OD
JOIN Shoe S ON OD.ShoeId = S.Id
JOIN Brand B ON S.BrandId = B.Id
WHERE OD.CreatedDate BETWEEN DATEADD(MONTH,-1,GETDATE()) AND GETDATE()
GROUP BY B.BrandName,B.Id
ORDER BY Total DESC;", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                brand.Id = Convert.ToInt32(reader["Id"]);
                brand.BrandName = reader["BrandName"].ToString();
                brand.Total = Convert.ToDouble(reader["Total"]);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return brand;
        }
        public MostLeastSoldBrandThisMonth GetLeastSoldBrand()
        {
            MostLeastSoldBrandThisMonth brand = new MostLeastSoldBrandThisMonth();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) (SUM(OD.Price*OD.Quantity)) AS Total,B.BrandName,B.Id FROM OrderDetails OD
JOIN Shoe S ON OD.ShoeId = S.Id
JOIN Brand B ON S.BrandId = B.Id
WHERE OD.CreatedDate BETWEEN DATEADD(MONTH,-1,GETDATE()) AND GETDATE()
GROUP BY B.BrandName,B.Id
ORDER BY Total ASC;", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                brand.Id = Convert.ToInt32(reader["Id"]);
                brand.BrandName = reader["BrandName"].ToString();
                brand.Total = Convert.ToDouble(reader["Total"]);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return brand;
        }
        public MostSpentMoneyCustomerModel GetMostSpentCustomer()
        {
            MostSpentMoneyCustomerModel customer = new MostSpentMoneyCustomerModel();
            DatabaseConnection.Connect();
            SqlCommand command = new SqlCommand(@"SELECT TOP(1) (SUM(OD.Price*OD.Quantity)) AS Total,C.UserName,C.Id FROM OrderDetails OD
JOIN Orders O ON OD.OrderId = O.Id
JOIN Customer C ON O.CustomerId = C.Id
WHERE OD.CreatedDate BETWEEN DATEADD(MONTH,-3,GETDATE()) AND GETDATE()
GROUP BY C.UserName,C.Id
ORDER BY Total DESC;", DatabaseConnection._connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customer.Id = Convert.ToInt32(reader["Id"]);
                customer.UserName = reader["UserName"].ToString();
                customer.Total = Convert.ToDouble(reader["Total"]);
            }
            reader.Close();
            DatabaseConnection._connection.Close();
            return customer;
        }
    }
}
