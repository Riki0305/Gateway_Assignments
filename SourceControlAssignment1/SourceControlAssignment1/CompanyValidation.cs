using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlAssignment1
{
    public class CompanyValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string message = value.ToString();
                if(message.Contains("COM"))
                {
                    return ValidationResult.Success;
                }

               
            }
            return new ValidationResult("The code must contain 'COM' keyword");
        }
    }
}