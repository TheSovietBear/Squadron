using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Squadron.Models;

namespace Squadron.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Squadron.Models.ArmoredVehicle> ArmoredVehicle { get; set; } = default!;
        public DbSet<Squadron.Models.JetPlane> JetPlane { get; set; } = default!;
    }
}
