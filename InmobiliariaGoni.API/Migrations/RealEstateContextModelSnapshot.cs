using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using InmobiliariaGoni.Models;

namespace InmobiliariaGoni.API.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    partial class RealEstateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InmobiliariaGoni.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("InmobiliariaGoni.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AvailableFrom");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("HouseCode");

                    b.Property<string>("HouseTitle");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("InmobiliariaGoni.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("HouseId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("InmobiliariaGoni.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("HouseId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("InmobiliariaGoni.Models.House", b =>
                {
                    b.HasOne("InmobiliariaGoni.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("InmobiliariaGoni.Models.Image", b =>
                {
                    b.HasOne("InmobiliariaGoni.Models.House")
                        .WithMany()
                        .HasForeignKey("HouseId");
                });

            modelBuilder.Entity("InmobiliariaGoni.Models.Tag", b =>
                {
                    b.HasOne("InmobiliariaGoni.Models.House")
                        .WithMany()
                        .HasForeignKey("HouseId");
                });
        }
    }
}
