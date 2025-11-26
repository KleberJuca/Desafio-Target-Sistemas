using Desafio_Target_Sistemas.Interface;
using Desafio_Target_Sistemas.Service;

namespace Desafio_Target_Sistemas.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDesafioService, DesafioService>();
            return services;
        }
    }
}
