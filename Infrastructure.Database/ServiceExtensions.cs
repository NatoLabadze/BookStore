using Core.Application.Interfaces.Repositories;
using Infrastructure.Database.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.Database
{
    public static class ServiceExtensions
    {
        public static void AddDbLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookStoreDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("BookStoreDbConn")));
            services.AddScoped<IBookRepository, BookRepository>();

        }
    }
}
