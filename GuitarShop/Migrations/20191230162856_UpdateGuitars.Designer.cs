﻿// <auto-generated />
using GuitarShop.Database;
using GuitarShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuitarShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191230162856_UpdateGuitars")]
    partial class UpdateGuitars
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuitarShop.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ContactMe");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("GuitarShop.Models.Guitar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackWood");

                    b.Property<string>("Builder");

                    b.Property<bool>("IsGuitarOfTheWeek");

                    b.Property<string>("Model");

                    b.Property<decimal>("Price");

                    b.Property<string>("TopWood");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Guitars");
                });
#pragma warning restore 612, 618
        }
    }
}
