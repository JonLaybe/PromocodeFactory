using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Common.Interfaces;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System.Reflection;

namespace PromoCodeFactory.DataAccess.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public static bool Initialized { get; protected set; } = false;

        public DbSet<Employee> Employees => this.Set<Employee>();

        public DbSet<Role> Roles => this.Set<Role>();

        public DbSet<Customer> Customers => this.Set<Customer>();

        public DbSet<Preference> Preferences => this.Set<Preference>();

        public DbSet<PromoCode> PromoCodes => this.Set<PromoCode>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            if (!Initialized)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
                SQLitePCL.Batteries_V2.Init();

                //Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            ApplicationDbContext.Initialized = true;
        }
    }
}
