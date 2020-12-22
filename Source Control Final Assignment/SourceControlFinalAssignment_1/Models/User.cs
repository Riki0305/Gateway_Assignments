using SourceControlFinalAssignment_1.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment_1.Models
{
    public class User
    {

        //Server Side Validations
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Username")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [CodeValidator]
        [StringLength(15)]
        [Display(Name="User code (ex.454EMP)")]
        public string Code { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15)]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15)]
        public string ConfirmPassword { get; set; }
        [Required]
        [Range(18, 50, ErrorMessage = "Age must be between 18 to 50")]
        public int Age { get; set; }

        
        [StringLength(100)]
        [Display(Name="User Image")]
        
        public string ImagePath { get; set; }
    }
}