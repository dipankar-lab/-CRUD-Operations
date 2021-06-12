using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName ="varchar(50)")]
        [Required]
        public string Password { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Required]
        public string Contact { get; set; }

        [Required]
        public bool Terms { get; set; }

        [Column(TypeName = "char(2)")]
        [Required] 
        public string Gender { get; set; }
       
        [ForeignKey("City")]
        public int CityId  { get; set; }
        public City City { get; set; }
    }
}
