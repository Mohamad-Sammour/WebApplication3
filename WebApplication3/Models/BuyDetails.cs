using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class BuyDetails
    {
        [Key]
        public int Id { get; set; }

        public int BuyId { get; set; }
        //[ForeignKey("ID")]
        //public virtual Buy by { get; set; }
        public int MealId { get; set; }
        public int Quantity { get; set; }
    }
}