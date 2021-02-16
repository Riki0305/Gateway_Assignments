using Product_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Management.ViewModels
{
    public class ProductFormViewModel
    {
        public Product product { get; set; }
        public IEnumerable<Category> category { get; set; }
    }
}