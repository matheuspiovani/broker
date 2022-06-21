using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using broker.Models;

namespace broker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<broker.Models.Stock>? Stock { get; set; }
        public DbSet<broker.Models.Alert>? Alert { get; set; }
        public DbSet<broker.Models.ApplicationUser>? ApplicationUser { get; set; }
    }
}
