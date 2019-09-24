using Newtonsoft.Json;
using OnlineShoppingCart.DAL;
using OnlineShoppingCart.DAL.EF;
using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingCart.Controllers
{
    public class AdminController : Controller
    {
        public Repository<tblCategory> repositoryCategory;
        public Repository<tblProduct> repositoryProduct;
        public AdminController()
        {
            repositoryCategory = new Repository<tblCategory>(new OnlineshoppingDBEntities());
            repositoryProduct = new Repository<tblProduct>(new OnlineshoppingDBEntities());
        }

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> lstcat = new List<SelectListItem>();
            var cat = repositoryCategory.GetAllEntity();
            foreach (var item in cat)
            {
                lstcat.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
            }
            return lstcat;
        }
        // GET: Admin
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<tblCategory> GetAll = repositoryCategory.GetAllByIQueryable().Where(v => v.CategoryIsDelete == false).ToList();
            return View(GetAll);
        }

        public ActionResult AddCategory()
        {
            return CategoryEdit(0);
        }
        public ActionResult CategoryEdit(int ID)
        {
            CategoryVM cvm;
            if (ID == 0)
                return View(new CategoryVM());
            else
            {
                var cvmm = repositoryCategory.GetByID(ID);
                cvm = new CategoryVM()
                {
                    CategoryID = cvmm.CategoryID,
                    CategoryIsActive = cvmm.CategoryIsActive,
                    CategoryIsDelete = cvmm.CategoryIsDelete,
                    CategoryName = cvmm.CategoryName
                };
                return View(cvm);
            }
        }
        [HttpPost]
        public ActionResult CategoryEdit(CategoryVM cvm)
        {
            tblCategory tcvm;
            tcvm = new tblCategory()
            {
                CategoryID = cvm.CategoryID,
                CategoryIsActive = cvm.CategoryIsActive,
                CategoryIsDelete = cvm.CategoryIsDelete,
                CategoryName = cvm.CategoryName
            };
            repositoryCategory.UpdateEntity(tcvm);
            repositoryCategory.Save();
            return RedirectToAction("Categories");
        }

        public ActionResult Products()
        {
            List<tblProduct> products = repositoryProduct.GetAllEntity().ToList();
            return View(products);
        }
        public ActionResult AddProduct()
        {
            ViewBag.getcategories = GetCategory();
            return ProductEdit(0);
        }

        [HttpPost]
        public ActionResult AddProduct(tblProduct product)
        {
            product.CreateDate = DateTime.Now;
            product.ModifiedDate = DateTime.Now;
            repositoryProduct.AddEntity(product);
            repositoryProduct.Save();
            return RedirectToAction("Products");
        }
        public ActionResult ProductEdit(int ID)
        {
            ViewBag.getcategories = GetCategory();
            if (ID == 0)
                return View(new tblProduct());
            else
            {
                tblProduct pvm = repositoryProduct.GetByID(ID);
                return View(pvm);
            }
        }
        [HttpPost]
        public ActionResult ProductEdit(tblProduct product)
        {
            product.CreateDate = DateTime.Now;
            product.ModifiedDate = DateTime.Now;
            repositoryProduct.UpdateEntity(product);
            repositoryProduct.Save();
            return RedirectToAction("Products");
        }
    }
}