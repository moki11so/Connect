namespace Moki11so.Shared.Orders
{
    public abstract class OrderAddressBase
    {
        public string Firma { get; set; }
        public string FirmenZusatz { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string Plz { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
