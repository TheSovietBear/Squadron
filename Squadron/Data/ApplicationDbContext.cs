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

        public DbSet<ArmoredVehicle> ArmoredVehicle { get; set; } = default!;
        public DbSet<JetPlane> JetPlane { get; set; } = default!;
    }
}

 


