using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using travellersApi.Data;
using travellersApi.Interfaces;
using travellersApi.Services;

namespace travellersApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
         public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config){
           services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options => {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
         }
    }
}