using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Stock_Project.Models.Entity;

namespace Mvc_Stock_Project.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Mvcdb_StockEntities db = new Mvcdb_StockEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult newSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newSale(Tbl_Sales p1)
        {
            db.Tbl_Sales.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}