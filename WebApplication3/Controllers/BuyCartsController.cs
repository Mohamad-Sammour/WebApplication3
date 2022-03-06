using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BuyCartsController : Controller
    {

        [HttpPost]
        [Authorize]
        public ActionResult Buy()
        {

            var db = new ApplicationDbContext(); //obj from database

            //Save To buy
            db.Buys.Add(new Buy { Email = User.Identity.Name, DateTime = DateTime.Now }); //add new data in table buy from (new)
            db.SaveChanges();

            //get the last id 
            var buyid = (from b in db.Buys 
                         where b.Email == User.Identity.Name 
                         select b.Id).Max(); // show the person who buy and the max its mean the  last one who register or login in database

            //get cart data based userid who confirme the order 
            IEnumerable<Carts> carts = db.Carts.Where(c => c.Email == User.Identity.Name);
            

            //add to buy Details
            foreach(var c in carts)
            {

                db.BuyDetails.Add(new BuyDetails { BuyId = buyid, Quantity = c.Quantity, MealId = c.MealId });
            }

            //Delete From Cart
            db.Carts.RemoveRange(carts); //RemoveRange : Delete list from data based on email 
            db.SaveChanges();

            Session["success"] = "Successfully"; // session is the transef data from ActionMethod To View 
            return RedirectToAction("Home", "Customer");
        }
    }
}