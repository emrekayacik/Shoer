using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Entity.CustomerContact
{
   public class CustomerContact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNo { get; set; }
        public int CustomerId { get; set; }
    }
}
