using System;

namespace Shoer.Entity.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPayment { get; set; }
        public bool IsDeleted { get; set; }
        public int CustomerId { get; set; }
    }
}
