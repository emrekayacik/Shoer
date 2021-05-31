using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Entity.Customer
{
   public class Customer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string CustomerPassword { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
