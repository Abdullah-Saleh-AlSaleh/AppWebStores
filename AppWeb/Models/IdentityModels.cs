using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }
        [Display(Name = "حي")]
        public string District { get; set; }
        [Display(Name = "المدينة")]
        public string City { get; set; }
        [Display(Name = "شارع")]
        public string Street { get; set; }
        [Display(Name = "موقع")]
        public string Location { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public static class IdentityExtensions
    {
        public static string FullName(this IIdentity identity)
        {
            var userId = identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {

                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user.FullName;

            }


        }
             public static string District(this IIdentity identity)
        {
            var userId = identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {

                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user.District;

            }


        }
             public static string City(this IIdentity identity)
              {
            var userId = identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {

                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user.City;

            }


        }
             public static string Street(this IIdentity identity)
        {
            var userId = identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {

                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user.Street;

            }


        }
             public static string NumberMobie(this IIdentity identity)
        {
            var userId = identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {

                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user.PhoneNumber;

            }


        }
             public static string GetEmail(this IIdentity identity)
        {
            var userId = identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {

                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user.Email;

            }


        }

    }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AppWeb.Models.Store> Stores { get; set; }
        public System.Data.Entity.DbSet<AppWeb.Models.Comment> Comments { get; set; }


        public System.Data.Entity.DbSet<AppWeb.Models.AddStore> AddStores { get; set; }

    }
}