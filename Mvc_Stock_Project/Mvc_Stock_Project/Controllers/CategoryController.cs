using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Stock_Project.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Mvc_Stock_Project.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Mvcdb_StockEntities db=new Mvcdb_StockEntities();
        public ActionResult Index(int page=1)
        {
            //var categories=db.Tbl_Categories.ToList();
            var categories = db.Tbl_Categories.ToList().ToPagedList(page, 4);
            return View(categories);
        }
        [HttpGet]
        public ActionResult newCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newCategory(Tbl_Categories p1)
        {
            if (!ModelState.IsValid)
            {
                return View("newCategory");
            }
            db.Tbl_Categories.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
             var category=db.Tbl_Categories.Find(id);
            db.Tbl_Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringCategory(int id)
        {
            var ctgr=db.Tbl_Categories.Find(id);
            return View("BringCategory",ctgr);
        }
        public ActionResult Update(Tbl_Categories p1)
        {
            var ctg = db.Tbl_Categories.Find(p1.ctg_ID);
            ctg.ctg_name= p1.ctg_name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            

    }
}