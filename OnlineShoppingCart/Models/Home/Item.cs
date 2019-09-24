using OnlineShoppingCart.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart.Models.Home
{
    public class Item
    {
        public tblProduct product { get; set; }
        public int quantity { get; set; }
    }
}