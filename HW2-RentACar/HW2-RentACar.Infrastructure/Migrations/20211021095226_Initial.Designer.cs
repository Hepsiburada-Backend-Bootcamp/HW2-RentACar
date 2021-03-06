// <auto-generated />
using System;
using HW2_RentACar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HW2_RentACar.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211021095226_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HW2_RenACar.Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ModelYear = 2020,
                            Name = "Fiat",
                            Price = 250.0
                        },
                        new
                        {
                            Id = 2,
                            ModelYear = 2019,
                            Name = "BMW",
                            Price = 350.0
                        },
                        new
                        {
                            Id = 3,
                            ModelYear = 2021,
                            Name = "Mercedes",
                            Price = 350.0
                        },
                        new
                        {
                            Id = 4,
                            ModelYear = 2018,
                            Name = "Ford",
                            Price = 200.0
                        });
                });

            modelBuilder.Entity("HW2_RenACar.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "İlker",
                            LastName = "Baltacı"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Abuzer",
                            LastName = "Kömürcü"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Eşref",
                            LastName = "Bitlis"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Tombalacı",
                            LastName = "Mehmet"
                        });
                });

            modelBuilder.Entity("HW2_RenACar.Domain.Entities.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentingDayDuration")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.ToTable("Rents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 3,
                            ClientId = 1,
                            CreatedAt = new DateTime(2021, 10, 21, 12, 52, 25, 611, DateTimeKind.Local).AddTicks(702),
                            RentingDayDuration = 3,
                            TotalPrice = 1050.0
                        },
                        new
                        {
                            Id = 2,
                            CarId = 1,
                            ClientId = 3,
                            CreatedAt = new DateTime(2021, 10, 21, 12, 52, 25, 613, DateTimeKind.Local).AddTicks(3742),
                            RentingDayDuration = 4,
                            TotalPrice = 1000.0
                        },
                        new
                        {
                            Id = 3,
                            CarId = 4,
                            ClientId = 4,
                            CreatedAt = new DateTime(2021, 10, 21, 12, 52, 25, 613, DateTimeKind.Local).AddTicks(3774),
                            RentingDayDuration = 5,
                            TotalPrice = 1000.0
                        });
                });

            modelBuilder.Entity("HW2_RenACar.Domain.Entities.Rent", b =>
                {
                    b.HasOne("HW2_RenACar.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HW2_RenACar.Domain.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("HW2_RenACar.Domain.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
