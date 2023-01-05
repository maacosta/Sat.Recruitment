using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Repositories.Impl;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Services.Impl;

namespace Sat.Recruitment.Api.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailNormalizer, EmailNormalizer>();
            services.AddScoped<IUserDuplicationValidator, UserDuplicationValidator>();
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
            services.AddScoped<IWelcomeUserGiftService, WelcomeUserGiftService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
