using CustomerService.Application.Services.Authentication;
using CustomerService.Application.Services.Customers.GetCustomers;
using CustomerService.Application.Services.SupportRequestMessages.CreateSupportRequestMessage;
using CustomerService.Application.Services.SupportRequests.CreateSupportRequest;
using CustomerService.Application.Services.SupportRequests.GetSupportRequest;
using CustomerService.Application.Services.SupportRequests.UpdateStatus;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICreateSupportRequestService, CreateSupportRequestService>();
            services.AddScoped<ICreateSupportRequestMessageService, CreateSupportRequestMessageService>();
            services.AddScoped<IGetSupportRequestService, GetSupportRequestService>();
            services.AddScoped<IUpdateSupportRequestStatusService, UpdateSupportRequestStatusService>();
            services.AddScoped<IGetCustomersService, GetCustomersService>();

            return services;
        }
    }
}
