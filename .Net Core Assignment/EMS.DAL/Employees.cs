using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.DAL
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public bool IsManager { get; set; }
        [Required]
        [StringLength(50)]
        public string Manager { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
