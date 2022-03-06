using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Meals
    {
        public int id { get; set; }
        public string Name { get; set;} 
 public double prics { get; set; }

        public string category { get; set; }
        public string image { get; set; }

    }
}