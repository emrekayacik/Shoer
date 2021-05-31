using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Entity.Order
{
   public class Order
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public string OrderDate { get; set; }
        public double TotalPayment { get; set; }
        public bool IsDeleted { get; set; }
        public int CustomerId { get; set; }
    }
}
