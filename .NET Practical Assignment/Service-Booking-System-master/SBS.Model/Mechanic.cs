using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Mechanic
    {
        [Key]
        public int Id { get; set; }
        public string MechanicNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        
        public string Make { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
