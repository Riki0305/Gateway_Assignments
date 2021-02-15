using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="service")]
        [Required]
        public int ServiceId { get; set; }
        
        public int CustomerId { get; set; }
        public Nullable<int> MechanicId { get; set; }
        [Display(Name = "Vehicle")]
        [Required]
        public int VehicleId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Booking Start Date")]
        [Required]
        public System.DateTime BookingStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "booking End Date")]
        [Required]
        public System.DateTime BookingEnd { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public virtual Service Service { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
