using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleGo.Models
{
    public class OrdersProducts
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Order")]
        public int OrderID { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}