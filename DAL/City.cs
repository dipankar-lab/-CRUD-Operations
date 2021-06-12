using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }  
      
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
