using System.Collections.Generic;

namespace WebApiAssignment.Model
{
    public class Room_Category
    {
        public int Id { get; set; }
        public string Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}