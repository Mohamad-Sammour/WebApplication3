using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class CustomerController : Controller
    {
        
        ApplicationDbContext db = new ApplicationDbContext();
        public static string catid = "Salad";

         // GET: Customer
        public ActionResult Home()
        {
            ViewData["cats"] = db.Meals;

            var meal = db.Meals.Where(m => m.category == catid);
            ShowCart();
            return View(meal);
        }

        public ActionResult Details(string category)
        {
            ViewData["cats"] = db.Meals;

            var meal = db.Meals.Where( m => m.category == category);// Lambda Expression
            ShowCart();

            return View("Home",meal);
        }


        //[HttpGet]
        //public ActionResult AddToCart()
        //{
        //    return View();
        //}

        [Authorize]
        public ActionResult AddToCart(int id)
        {
            ViewData["cats"] = db.Meals;
            var cart = db.Carts.SingleOrDefault(m =>m.MealId == id && m.Email == User.Identity.Name);
            var getmeal = db.Meals.SingleOrDefault(m => m.id == id); //بجيب الداتا اللي كبست عليها
            var meal = db.Meals.Where(m => m.category == catid);
            ShowCart();


            if (cart == null)
            {
                var carts = new Carts();

                carts.MealId = id;
                carts.Email = User.Identity.Name;
                carts.Quantity = 1;
                db.Carts.Add(carts);

                meal = db.Meals.Where(m => m.category == catid);

            }
            else
            {
                cart.Quantity++;
                meal = db.Meals.Where(m => m.category == getmeal.category);

            }

            db.SaveChanges();

            return View("Home",meal);
        }

        public void ShowCart() //show the cart by email of customer
        {
            var cartTable = from m in db.Meals
                            join c in db.Carts
                            on m.id equals c.MealId //on for anything 
                            where c.Email == User.Identity.Name
                            select new MealCartVM {Meals=m, Carts=c };

            ViewData["CartMeal"] = cartTable;
        }

        public ActionResult DeleteItem(int id)
        {
            ViewData["cats"] = db.Meals;
            var cart = db.Carts.SingleOrDefault(c => c.MealId == id && c.Email == User.Identity.Name); //SingleOrDefault it mean Delete One Data or One Record(
            ShowCart();

            if(cart.Quantity==1)
            {
                //db.Carts.Remove(db.Carts.Find(cart)); the code did run but also show the error here 
                db.Carts.Remove(db.Carts.SingleOrDefault(c => c.MealId == id && c.Email == User.Identity.Name));
                
            }

           else
            {
                cart.Quantity--;
            }
            db.SaveChanges();
            return View("Home");

        }
    }
}