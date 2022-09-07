using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("RentACarCampConnectionString")));
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}

//CQRS- Klasik bir uygulamada class açıyoruz. bütün metodları ona yerleştiriyoruz.
//query ise adı üstünde en basit haliyle select operasyonlarını yazacağımız şeyler,comment database'de değişiklik yapan insert,update, delete operasyonları yapan şeyler
//İşte CQRS, uygulamalarımızda bu istekleri karşılayacak olan yapılanmaları birbirinden ayırmamızı önermektedir.