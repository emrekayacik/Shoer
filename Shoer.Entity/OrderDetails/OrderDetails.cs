using System;

namespace Shoer.Entity.OrderDetails
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
