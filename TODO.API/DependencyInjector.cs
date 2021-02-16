using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TODO.Domain.Contracts.Database;
using TODO.Domain.Contracts.Repositories;
using TODO.Domain.Contracts.Services;
using TODO.Domain.Services;
using TODO.Infrastructure.Database;
using TODO.Infrastructure.Repositories;
using TODOLib.Config;

namespace TODO.API
{
    public class DependencyInjector
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration)
        {
            ResolveServices(services);
            ResolveRepositories(services);
            ResolveAdditionals(services);
            ResolveInterfaces(services);
        }

        private static void ResolveRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryTODO, RepositoryTODO>();
        }

        private static void ResolveServices(IServiceCollection services)
        {
            services.AddScoped<IServiceTODO, ServiceTODO>();
        }

        private static void ResolveInterfaces(IServiceCollection services)
        {
            services.AddScoped<IDatabase, JsonDatabase>();
        }

        private static void ResolveAdditionals(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(prov => AutoMapperProfileConfiguration.MapperConfiguration().CreateMapper());

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TODO API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddHttpClient();
        }
    }
}
