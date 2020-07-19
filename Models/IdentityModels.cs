using System.Collections.Generic;
using System.Collections;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleGo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual Seller Seller { get; set; }
        ////[ForeignKey("Seller")]
        ////public string SellerID { get; set; }

        public virtual Buyer Buyer { get; set; }
        ////[ForeignKey("Buyer")]
        ////public string BuyerID { get; set; }

        public virtual Admin Admin { get; set; }
        //[ForeignKey("Admin")]
        //public string AdminID { get; set; }

        //public virtual ICollection<Admin> Admins { get; set; }
        //public virtual ICollection<Seller> Sellers { get; set; }
        //public virtual ICollection<Buyer> Buyers { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("connection1", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }




        public System.Data.Entity.DbSet<TeleGo.Models.Admin> Admins { get; set; }

        //public System.Data.Entity.DbSet<TeleGo.Models.IdentityModels> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<TeleGo.Models.Seller> Sellers { get; set; }

        public System.Data.Entity.DbSet<TeleGo.Models.Buyer> Buyers { get; set; }

        public System.Data.Entity.DbSet<TeleGo.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<TeleGo.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<TeleGo.Models.Order> Orders { get; set; }
    }
}