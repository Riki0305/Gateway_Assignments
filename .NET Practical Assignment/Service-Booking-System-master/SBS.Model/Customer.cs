using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }
        public string CustomerNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Enter valid pincode")]
        public string ZipCode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Contact { get; set; }
        [Display(Name="Home Contact")]
        public string HomeContact { get; set; }
        public string Note { get; set; }
       
        public virtual ICollection<Booking> Bookings { get; set; }
        
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
