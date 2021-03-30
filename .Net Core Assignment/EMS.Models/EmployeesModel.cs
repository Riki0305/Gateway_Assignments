using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class EmployeesModel
    {
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
        [EmailAddress]
        public string Email { get; set; }
    }
}
