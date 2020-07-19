using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleGo.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public byte[] CategoryIcon { get; set; }
        public virtual ICollection<Product> Products { get; set; }



        [ForeignKey("Admin")]
        public string AdminID { get; set; }
        public Admin Admin { get; set; }
    }
}