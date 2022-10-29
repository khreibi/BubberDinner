using BubberDinner.Application.Common.Authentification;
using BubberDinner.Application.Services.Authentification;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthentificationService, AuthentificationService>();
            
            return services;
        }
    }
}
