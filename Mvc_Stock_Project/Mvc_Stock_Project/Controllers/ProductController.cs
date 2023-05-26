using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Mvc_Stock_Project.Models.Entity;

namespace Mvc_Stock_Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Mvcdb_StockEntities db=new Mvcdb_StockEntities();
        public ActionResult Index()
        {
            var pct =db.Tbl_Products.ToList();
            return View(pct);
        }
        [HttpGet]
        public ActionResult newProduct()
        {
            List<SelectListItem> pct=(from i in db.Tbl_Categories.ToList()
                select new SelectListItem()
               {
                Text = i.ctg_name,
                Value = i.ctg_ID.ToString()
               }).ToList();
            ViewBag.dgr=pct;

                return View();
        }
        [HttpPost]
        public ActionResult newProduct(Tbl_Products p1)
        {
            var ctg=db.Tbl_Categories.Where(m=>m.ctg_ID==p1.Tbl_Categories.ctg_ID).FirstOrDefault();
            p1.Tbl_Categories= ctg;
            db.Tbl_Products.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = db.Tbl_Products.Find(id);
            db.Tbl_Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringProduct(int id)
        {
            var pct = db.Tbl_Products.Find(id);
            List<SelectListItem> pdt = (from i in db.Tbl_Categories.ToList()
                                        select new SelectListItem()
                                        {
                                            Text = i.ctg_name,
                                            Value = i.ctg_ID.ToString()
                                        }).ToList();
            ViewBag.dgr = pdt;
            return View("BringProduct", pct);
        }
        public ActionResult Update(Tbl_Products p1)
        {
            var pct = db.Tbl_Products.Find(p1.pct_ID);
            pct.pct_name = p1.pct_name;
            pct.pct_brand = p1.pct_brand;
            pct.pct_price = p1.pct_price;
            pct.pct_stock = p1.pct_stock;
            // pct.pct_category = p1.pct_category;
            var ctg = db.Tbl_Categories.Where(m => m.ctg_ID == p1.Tbl_Categories.ctg_ID).FirstOrDefault();
            pct.pct_category = ctg.ctg_ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}