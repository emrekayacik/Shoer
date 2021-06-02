using Shoer.Entity.Shoe;
using System.Collections.Generic;

namespace Shoer.Models
{
    public class Cart
    {
        public List<Shoe> Shoes { get; set; }
        public Cart()
        {
            Shoes = new List<Shoe>();
        }
    }

}
