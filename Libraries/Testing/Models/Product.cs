using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Testing.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        public string ProductPrice { get; set; }
        public string Image { get; set; }
    }
}