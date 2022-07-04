using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddAppLayer(this IServiceCollection services, IConfiguration configuration)
        {
    
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
       

        }
    }
}
