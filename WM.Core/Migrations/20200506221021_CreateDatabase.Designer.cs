﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WM.Core.Repository;

namespace WM.Core.Migrations
{
    [DbContext(typeof(StoreDBContext))]
    [Migration("20200506221021_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WM.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = 0,
                            Description = "Store fresh at 7C",
                            Manufacturer = "PACIFIC FRUIT LTD DOO",
                            Name = "Banana",
                            Price = 64.0,
                            Supplier = "Maxi"
                        },
                        new
                        {
                            Id = 2,
                            Category = 1,
                            Description = "White potatoes",
                            Manufacturer = "FRUIT COMPANY DOO",
                            Name = "Potato",
                            Price = 33.0,
                            Supplier = "Maxi"
                        },
                        new
                        {
                            Id = 3,
                            Category = 3,
                            Description = "Nutella cream 750g",
                            Manufacturer = "DELTA DMD DOO",
                            Name = "Nutella",
                            Price = 689.99000000000001,
                            Supplier = "Maxi"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
