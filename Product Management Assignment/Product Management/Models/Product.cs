using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product_Management.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Short Description")]
        public string ShortDesc { get; set; }
        [Required]
        [Display(Name = "Long Description")]
        public string LongDesc { get; set; }
        [Required]
        [Display(Name="Small Image")]
        public string SmallImagePath { get; set; }
        [Required]
        [Display(Name = "Large Image")]
        public string LongImagePath { get; set; }
    }
}