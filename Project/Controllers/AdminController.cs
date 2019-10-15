using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult ProductDetail()
        {
            using (ShopEntities db = new ShopEntities())
            {
                var model = db.Products;
                return PartialView(model);
            }
            
        }
    }
}