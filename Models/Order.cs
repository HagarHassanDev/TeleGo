using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleGo.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("Buyer")]
        public string BuyerID { get; set; }
        public Buyer Buyer { get; set; }
        public BillMethod billMethod { get; set; }


        //=====
        //public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<OrdersProducts> Products { get; set; }



    }
}