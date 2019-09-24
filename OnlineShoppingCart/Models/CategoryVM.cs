using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingCart.Models
{
    public class CategoryVM
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Category is requierd.")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public Nullable<bool> CategoryIsActive { get; set; }
        public Nullable<bool> CategoryIsDelete { get; set; }
    }

    class ProductVM
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        [Range(typeof(int), "1", "500", ErrorMessage = "Invalid Quality.")]
        public Nullable<int> Quantity { get; set; }
        public Nullable<bool> ProductIsActive { get; set; }
        public Nullable<bool> ProductIsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ProductImage { get; set; }
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "Invalid price.")]
        public Nullable<decimal> Price { get; set; }
        public SelectList categories { get; set; }
    }
}