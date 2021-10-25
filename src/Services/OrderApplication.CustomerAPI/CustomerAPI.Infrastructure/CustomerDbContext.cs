using CustomerAPI.ApplicationCore.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderApplication.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerAPI.Infrastructure
{
    public class CustomerDbContext : DbContext
    {

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            var AddedEntities = ChangeTracker.Entries().Where(E => E.Entity is IAggregateRoot && E.State == EntityState.Added).ToList();
            
            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedAt").CurrentValue = DateTime.Now;
                E.Property("UpdatedAt").CurrentValue = DateTime.Now;

            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.Entity is IAggregateRoot && E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedAt").CurrentValue = DateTime.Now;
            });
            return base.SaveChangesAsync(cancellationToken);
        }
      
    }
}
