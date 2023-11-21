using DOAN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN.Controllers
{
    public class ToppingController : Controller
    {
        // GET: Topping
        DoAnWebbEntities database = new DoAnWebbEntities();
        public ActionResult Index()
        {
            return View(database.Toppings.ToList());
        }
        public ActionResult Create()
        {
            Topping details= new Topping();   
            return View(details);
        }
        [HttpPost]
        public ActionResult Create(Topping top)
        {
            try
            {
                database.Toppings.Add(top);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }

        }

        public ActionResult Edit(int id)
        {
            return View(database.Toppings.Where(s => s.Matop == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Topping top)
        {
            database.Entry(top).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.Toppings.Where(s => s.Matop == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Topping top)
        {
            try
            {
                top = database.Toppings.Where(s => s.Matop == id).FirstOrDefault();
                database.Toppings.Remove(top);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }

        }
    }
}