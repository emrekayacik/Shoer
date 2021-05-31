using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Entity.Admin_Manages_Orders
{
   public class Admin_Manages_Orders
    {
        public int Id { get; set; }
        public string StatusEditDate { get; set; }
        public int OrderId { get; set; }
        public int AdminId { get; set; }
    }
}
