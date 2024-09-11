namespace Locations.Models
{
    public class LocationDetail
    {

        public  int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string phone { get; set; }

        public double latitude { get; set; }
        public double longitude { get; set; }
        public string Company { get; set; }
    }
}
