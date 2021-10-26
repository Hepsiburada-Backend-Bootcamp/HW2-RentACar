using HW2_RenACar.Domain.Repositories.Dapper;
using HW2_RenACar.Domain.Repositories.EntityFrameworkCore;
using HW2_RentACar.Infrastructure.Context;
using HW2_RentACar.Infrastructure.Repositories.Dapper;
using HW2_RentACar.Infrastructure.Repositories.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Infrastructure
{
    public static class InfraModuleExtensions
    {
        public static IServiceCollection AddInfrastructureModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));
            
            services.AddDbContext<DapperContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));


            services.AddScoped<IEFCoreCarRepository, EFCoreCarRepository>();
            services.AddScoped<IEFCoreClientRepository, EFCoreClientRepository>();
            services.AddScoped<IEFCoreRentRepository, EFCoreRentRepository>();

            services.AddScoped<IDapperCarRepository, DapperCarRepository>();
            services.AddScoped<IDapperClientRepository, DapperClientRepository>();
            services.AddScoped<IDapperRentRepository, DapperRentRepository>();

            return services;
        }

        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // Takes all of our migrations files and apply them against the database in case they are not implemented
                serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
            }
        }
    }
}
