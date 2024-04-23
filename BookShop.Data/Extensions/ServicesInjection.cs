using BookShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Extensions
{
    public static class ServicesInjection
    {
        public static void AddProjectModules(this IServiceCollection services)
        {
            services.AddDbContext<BookShopDbContext>(ContextBoundObject => { ContextBoundObject.UseInMemoryDatabase("BookShopDB"); });
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
