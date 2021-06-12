using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class CityModel
    {
        public string CountryCode { get; set; }
        public int CityId { get; set; }

        public string Name { get; set; }

        public CountryModel Country { get; set; }

        
        }
       
    }

