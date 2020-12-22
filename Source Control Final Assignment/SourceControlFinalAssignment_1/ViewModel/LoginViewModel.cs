using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment_1.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string Name { get; set; }

        

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}