using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleGo.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
       
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int UnityInStock { get; set; }
        public bool ApprovalState { get; set; }
        public short ProductRate { get; set; }
        public virtual ICollection<Buyer> FavouriteBuyers { get; set; }

        //====
        //public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrdersProducts> Products { get; set; }

        //====

        public Seller Seller { get; set; }
        [ForeignKey("Seller")]
        public string SellerID { get; set; }

        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
    }
}