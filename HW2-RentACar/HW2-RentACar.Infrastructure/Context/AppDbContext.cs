using HW2_RenACar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 1, ModelYear = 2020, Name = "Fiat", Price = 250},
                new Car() { Id = 2, ModelYear = 2019, Name = "BMW", Price = 350},
                new Car() { Id = 3, ModelYear = 2021, Name = "Mercedes", Price = 350},
                new Car() { Id = 4, ModelYear = 2018, Name = "Ford", Price = 200}
                );

            modelBuilder.Entity<Client>().HasData(
                new Client() { Id = 1, FirstName = "İlker", LastName = "Baltacı"},
                new Client() { Id = 2, FirstName = "Abuzer", LastName = "Kömürcü"},
                new Client() { Id = 3, FirstName = "Eşref", LastName = "Bitlis"},
                new Client() { Id = 4, FirstName = "Tombalacı", LastName = "Mehmet"}
                );

            modelBuilder.Entity<Rent>().HasData(
                new Rent() { Id = 1, CarId = 3, ClientId = 1, CreatedAt = DateTime.Now, RentingDayDuration = 3, TotalPrice = 1050},
                new Rent() { Id = 2, CarId = 1, ClientId = 3, CreatedAt = DateTime.Now, RentingDayDuration = 4, TotalPrice = 1000},
                new Rent() { Id = 3, CarId = 4, ClientId = 4, CreatedAt = DateTime.Now, RentingDayDuration = 5, TotalPrice = 1000}
                );
        }
    }
}
