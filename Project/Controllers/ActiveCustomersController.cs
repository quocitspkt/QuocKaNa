using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.Models;

namespace Project.Controllers
{
    public class ActiveCustomersController : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: ActiveCustomers
        //public ActionResult Index()
        //{
        //    return View(db.Customers.ToList());
        //}

        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            //     var products = db.Products.Include(p => p.ProductCategory);
            var links = (from l in db.Customers
                         select l).OrderBy(x => x.Username);
            int pageSize = 3;
            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        // GET: ActiveCustomers/Details/5
        public ActionResult Details(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(username);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: ActiveCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActiveCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,FullName,Address,Email,Photo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: ActiveCustomers/Edit/5
        public ActionResult Edit(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(username);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: ActiveCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,FullName,Address,Email,Photo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: ActiveCustomers/Delete/5
        public ActionResult Delete(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(username);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: ActiveCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string username)
        {
            Customer customer = db.Customers.Find(username);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
