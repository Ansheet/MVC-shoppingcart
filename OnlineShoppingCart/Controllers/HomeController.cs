using OnlineShoppingCart.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        HomeIndexViewModel hivm;
        public HomeController()
        {
            hivm = new HomeIndexViewModel();
        }
        public ActionResult Index(string Search)
        {



            return View(hivm.CreateModel(Search));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddToCart(int productID)
        {

            Dictionary<int, Item> dct = new Dictionary<int, Item>();
            List<Item> lst = new List<Item>();
            List<Item> lstNew = new List<Item>();
            if (Session["cart"] != null)
            {
                lst = (List<Item>)Session["cart"];
                var temp = hivm.lstCart(productID);
                var unionlst = lst.Union(temp);
                foreach (var item in unionlst)
                {
                    if (!dct.ContainsKey(item.product.ProductID))
                    {
                        dct.Add(item.product.ProductID, item);
                    }
                    else
                    {
                        item.quantity += lst.Where(v => v.product.ProductID == item.product.ProductID).Select(av => av.quantity).FirstOrDefault();
                        dct[item.product.ProductID] = item;
                    }
                }
                lstNew = dct.Select(v => v.Value).ToList();
                Session["cart"] = lstNew;
            }
            else
                Session["cart"] = hivm.lstCart(productID);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productID)
        {

            List<Item> lsNew = new List<Item>();
            if (Session["cart"] != null)
            {
                lsNew = (List<Item>)Session["cart"];
                foreach (var item in lsNew)
                {
                    if (item.product.ProductID == productID)
                    {
                        lsNew.Remove(item);
                        break;
                    }
                }
                Session["cart"] = lsNew;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}