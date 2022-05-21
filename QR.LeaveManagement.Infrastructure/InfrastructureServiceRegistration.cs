using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QR.LeaveManagement.Application.Contracts.Infrastructure;
using QR.LeaveManagement.Application.Models;
using QR.LeaveManagement.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
