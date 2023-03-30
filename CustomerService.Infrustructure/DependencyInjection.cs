using CustomerService.Application.Common.Interfaces.Authentication;
using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Common.Interfaces.Services;
using CustomerService.Infrustructure.Authentication;
using CustomerService.Infrustructure.Persistence;
using CustomerService.Infrustructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(
            this IServiceCollection services, 
            ConfigurationManager configuration)
        {
            services.AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
         

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;

        }
    }
}