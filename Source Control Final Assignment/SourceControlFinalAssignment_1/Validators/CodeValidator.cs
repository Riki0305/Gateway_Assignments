using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment_1.Validators
{
    public class CodeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            

            if(value!=null)
            {
                string result = value.ToString();
                if (result.Contains("EMP"))
                {
                    return ValidationResult.Success;
                }

            }

            return new ValidationResult("Code must contain EMP phrase");
        }
    }
}