using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Entity.OrderDetails
{
   public class OrderDetails
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string CreatedDate { get; set; }
    }
}
