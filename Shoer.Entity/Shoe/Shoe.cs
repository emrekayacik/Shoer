using System;

namespace Shoer.Entity.Shoe
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShoeDescription { get; set; }
        public string ImageText { get; set; }
        public string Gender { get; set; }
        public double Price { get; set; }
        public int Size { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
