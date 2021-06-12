using System.Collections.Generic;

namespace DAL
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<City> City { get; set; }
    }
}
