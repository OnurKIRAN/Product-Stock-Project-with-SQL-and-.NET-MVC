using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Stock_Project;
using Mvc_Stock_Project.Models.Entity;

namespace Mvc_Stock_Project.Controllers
{
    public class CostumerController : Controller
    {
        // GET: Costumer
        Mvcdb_StockEntities db = new Mvcdb_StockEntities();
        public ActionResult Index(string p)
        {
            var values=from v in  db.Tbl_Costumers select v;
            if (!string.IsNullOrEmpty(p))
            {
                values=values.Where(m=>m.cst_name.Contains(p));
            }
            return View(values.ToList());
            //var cst = db.Tbl_Costumers.ToList();
            //return View(cst);
        }
        [HttpGet]
        public ActionResult newCostumer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newCostumer(Tbl_Costumers p1)
        {
            if (!ModelState.IsValid)
            {
                return View("newCostumer");
            }
            db.Tbl_Costumers.Add(p1);
            db.SaveChanges();
            return View();  
        }
        public ActionResult Delete(int id)
        {
            var costumer = db.Tbl_Costumers.Find(id);
            db.Tbl_Costumers.Remove(costumer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringCostumer(int id)
        {
            var cst = db.Tbl_Costumers.Find(id);
            return View("BringCostumer", cst);
        }
        public ActionResult Update(Tbl_Costumers p1)
        {
            var cst = db.Tbl_Costumers.Find(p1.cst_ID);
            cst.cst_name = p1.cst_name;
            cst.cst_surname = p1.cst_surname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}