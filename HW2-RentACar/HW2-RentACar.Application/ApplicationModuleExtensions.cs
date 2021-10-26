using HW2_RentACar.Application.ServiceInterfaces;
using HW2_RentACar.Application.Services;
using HW2_RentACar.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application
{
    public static class ApplicationModuleExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddInfrastructureModule(configuration);

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IRentService, RentService>();

            return services;
        }
    }
}
