using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShoppingCart;
using OnlineShoppingCart.Controllers;


namespace OnlineShoppingCart.unitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Contact()
        {
            HomeController hc = new HomeController();
            ViewResult vr = hc.Contact() as ViewResult;
            Assert.IsNotNull(vr);
        }

        [TestMethod]
        public void About()
        {
            HomeController hc = new HomeController();
            ViewResult vr = hc.About() as ViewResult;
            Assert.IsNotNull(vr);
        }
    }
}
