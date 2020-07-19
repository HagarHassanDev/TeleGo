using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleGo.Models
{
    public class Seller
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        //public int SellerID { get; set; }
        //public string SellerUserName { get; set; }
        //public string SellerPassword { get; set; }
        //public string SellerEmail { get; set; }
        public int SellerVisa { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }
       
        //public virtual ICollection<Buyer> FavouriteBuyers { get; set; }

    }
}