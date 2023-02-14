using Microsoft.AspNetCore.Mvc;

namespace Apartment.Models
{
    public class HomeViewModel
    {
        public List<Apartment.Data.Models.Apartment> Apartments { get; set; } = new List<Data.Models.Apartment>();
        public string Name { get; set; }
        [FromQuery(Name = "take")]
        public int Take { get; set; } = 10;
        [FromQuery(Name = "skip")]
        public int Skip { get; set; } = 0;
    }
}
