namespace Shoer.Entity.CustomerAdress
{
    public class CustomerAdress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public int ApartmentNo { get; set; }
        public int FlatNo { get; set; }
        public int CustomerId { get; set; }
    }
}
