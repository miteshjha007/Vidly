
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class VidlyDb : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public VidlyDb()
    : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static VidlyDb Create()
        {
            return new VidlyDb();
        }

    }
}