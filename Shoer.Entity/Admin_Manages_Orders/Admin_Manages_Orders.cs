using System;

namespace Shoer.Entity.Admin_Manages_Orders
{
    public class Admin_Manages_Orders
    {
        public int Id { get; set; }
        public DateTime StatusEditDate { get; set; }
        public int OrderId { get; set; }
        public int AdminId { get; set; }
    }
}
