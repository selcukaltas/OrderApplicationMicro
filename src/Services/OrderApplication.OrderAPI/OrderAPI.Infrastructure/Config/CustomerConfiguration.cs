using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.ApplicationCore.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
            builder.OwnsOne(c => c.OrderAddress, a =>
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
