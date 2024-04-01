using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using laptops.Models;

namespace laptops.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        internal IEnumerable<object> laptops;

        public DbSet<laptops.Models.Laptops> Laptops { get; set; } = default!;
    }
}
