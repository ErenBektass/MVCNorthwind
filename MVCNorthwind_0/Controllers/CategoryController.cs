using MVCNorthwind_0.DesignPatterns.SingletonPattern;
using MVCNorthwind_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthwind_0.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _db;
        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }

        // GET: Category
        public ActionResult ListCategories()
        {
            return View(_db.Categories.ToList());
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }


        public ActionResult UpdateCategory(int id)
        {
            return View(_db.Categories.Find(id));
        }


        [HttpPost]
        public ActionResult UpdateCategory(Category item)
        {
            Category guncellenecek = _db.Categories.Find(item.CategoryID);
            guncellenecek.CategoryName = item.CategoryName;
            guncellenecek.Description = item.Description;
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }


        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }
    }
}