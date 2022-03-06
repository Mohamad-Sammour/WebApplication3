using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{ 
    public class CMSMealsController : Controller
    {
        // GET: CMSMeals
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult list()
        { 
            var meal = db.Meals.ToList();
            return View(meal);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Meals meals, HttpPostedFileBase photo)
        {
            var fn = Path.GetFileName(photo.FileName);
            var path = Path.Combine(Server.MapPath("~/Upload"), fn);
            photo.SaveAs(path);
            meals.image = fn;

            db.Meals.Add(meals);
            db.SaveChanges();

            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var meal = db.Meals.Find(id);
            return View(meal);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_post(int id)
        {
            db.Meals.Remove(db.Meals.Find(id));
            db.SaveChanges();
            return RedirectToAction("list");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var meal = db.Meals.Find(id);
            return View(meal);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var meal = db.Meals.Find(id);
            return View(meal);
        }

        [HttpPost]
        public ActionResult Edit(Meals meals)
        {
            db.Entry(meals).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("list");
        }
    }
}