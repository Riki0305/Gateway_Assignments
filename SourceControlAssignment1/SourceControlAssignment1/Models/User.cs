using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SourceControlAssignment1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //custom validation
        [CompanyValidation]
        [DisplayName("Unique code")]
        public string UserCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{6})$",ErrorMessage ="Enter valid pincode")]
        public int Pincode { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Range(18,40,ErrorMessage ="Age should be between 18 to 40 only")]
        public int Age { get; set; }

        [Required]
        [DisplayName("Mobile No")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNom { get; set; }


        [MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Landline { get; set; }

        [Required]
        [DisplayName("Credit card No")]
        [CreditCard]
        public string CreditCard { get; set; }

        [StringLength(100)]
        [DisplayName("Profile Photo")]
        public string ImageName { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("Upload File")]
        public HttpPostedFileBase ImageFile { get; set; }





    }
}