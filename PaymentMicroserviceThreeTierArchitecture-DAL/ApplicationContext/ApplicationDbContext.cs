using Microsoft.EntityFrameworkCore;
using PaymentMicroserviceThreeTierArchitecture_DAL.Entities;

namespace PaymentMicroserviceThreeTierArchitecture_DAL.ApplicationContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Payment> Payments { get; set; }
    }
}
