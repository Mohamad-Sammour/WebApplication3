using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class MealCartVM
    {

        public Meals Meals { get; set; }
        public Carts Carts { get; set; }
    }
}