﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderAPI.Infrastructure;

namespace OrderAPI.Infrastructure.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderAPI.ApplicationCore.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderAPI.ApplicationCore.Domain.OrderAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("OrderAPI.ApplicationCore.Domain.OrderAggregate.Order", b =>
                {
                    b.HasOne("OrderAPI.ApplicationCore.Domain.OrderAggregate.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.OwnsOne("OrderAPI.ApplicationCore.Domain.OrderAggregate.Address", "OrderAddress", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("AddressLine")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("CityCode")
                                .HasColumnType("int");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("OrderAddress");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}