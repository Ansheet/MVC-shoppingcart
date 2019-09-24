using OnlineShoppingCart.DAL;
using OnlineShoppingCart.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingCart.Models.Home
{
    public class HomeIndexViewModel
    {
        public List<tblProduct> lstproducts { get; set; }

        public Repository<tblProduct> repositoryProduct;
        //OnlineshoppingDBEntities _context;
        public HomeIndexViewModel()
        {
            repositoryProduct = new Repository<tblProduct>(new OnlineshoppingDBEntities());
            //_context = new OnlineshoppingDBEntities();
        }
        public HomeIndexViewModel CreateModel(string search)
        {
            using (var _context = new OnlineshoppingDBEntities())
            {

                SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@searchText", search ?? (object)DBNull.Value)
            };
                //SqlParameter param = null;
                //SqlParameter param = new SqlParameter("@searchText", search ?? (object)DBNull.Value);
                //IEnumerable<tblProduct> lst = _context.Database.SqlQuery<tblProduct>("GetSearch @searchText", param);
                IEnumerable<tblProduct> lst = repositoryProduct.spCall("GetSearch @searchText", param);


                return new HomeIndexViewModel
                {
                    lstproducts = lst.ToList()
                };
            }
        }

        public List<Item> lstCart(int productID)
        {
            List<Item> cart = new List<Item>();
            var product = repositoryProduct.GetByID(productID);
            cart.Add(new Item()
            {
                product = product,
                quantity = 1
            });
            return cart;
        }
    }
}
