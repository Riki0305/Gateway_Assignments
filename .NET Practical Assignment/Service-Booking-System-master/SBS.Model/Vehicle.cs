using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "License Plate")]
        [Required]
        public string LicensePlate { get; set; }
        [Display(Name = "Brand")]
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Display(Name = "Chasis Number")]
        [Required]
        public string ChasisNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration date")]
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Owner")]
        public int OwnerId { get; set; }

       
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
