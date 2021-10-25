using CustomerAPI.ApplicationCore.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Infrastructure.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(c => c.CustomerAdress, a =>
             {
                  a.WithOwner();

                 a.Property(a => a.AddressLine);

                  a.Property(a => a.City).IsRequired();

                  a.Property(a => a.Country).IsRequired();

                  a.Property(a => a.CityCode).IsRequired();

            });
        }
    }
}
