using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleGo.Models
{
    public class Admin
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        //public int AdminID { get; set; }
        //public string AdminUserName { get; set; }
        //public string AdminPassword { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

    }
}