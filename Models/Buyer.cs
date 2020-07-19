using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeleGo.Models
{
    public class Buyer
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }


        // public int BuyerID { get; set; }
        //public string BuyerUserName { get; set; }
        //public string BuyerPassword { get; set; }
        //public string BuyerEmail { get; set; }


        public int BuyerVisa { get; set; }
        public int BuyerPhone { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
       
        public virtual ICollection<Product> FavouriteProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}