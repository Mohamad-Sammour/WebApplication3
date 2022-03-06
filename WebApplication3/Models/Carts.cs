using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Carts
    {

        public int Id { get; set;}
        public string Email { get; set; }
        public int MealId { get; set; }
        public int Quantity { get; set; }


    }
}