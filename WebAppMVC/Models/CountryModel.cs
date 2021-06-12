using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class CountryModel
    {
        [Required(ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }
        public string Country { get; set; }
    }
}
