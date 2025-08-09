using ASP_MVC.Filters;
using ASP_MVC.Middlewares;
using ASP_MVC.Repositories;
using ASP_MVC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ASP_MVC.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IExampleRepository, ExampleRepository>();
            services.AddScoped<IExampleService, ExampleService>();

            // Filters are added via MVC options; also register for DI
            services.AddScoped<GlobalExceptionFilter>();
            services.AddScoped<RequestLoggingActionFilter>();
            services.AddScoped<RequireHttpsPermanentFilter>();

            return services;
        }
    }
}



