using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string DealerNo { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{6})$",ErrorMessage = "Enter valid zipcode")]
        public int ZipCode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Contact { get; set; }           
    }
}
