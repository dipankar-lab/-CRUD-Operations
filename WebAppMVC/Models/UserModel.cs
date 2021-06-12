using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Attributes;

namespace WebAppMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
      
        public string Contact { get; set; }
       
        [ValidateCheckBox(ErrorMessage = "Please Accept Terms")]
        public bool Terms { get; set; }
         [Required(ErrorMessage = "Please Choose Gender")]
            //[ValidateRadioButton(ErrorMessage = "")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Select Country")]
        [DisplayName("Country")]
        //public string CountryCode { get; set; }
        public int CountryId { get; set; }
       

        [Required(ErrorMessage = "Please Select City")]
        [DisplayName("City")]
        public int CityId { get; set; }
       


    }
}
