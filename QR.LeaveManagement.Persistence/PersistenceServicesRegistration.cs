﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QR.LeaveManagement.Application.Contracts.Persistence;
using QR.LeaveManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {

        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementDbContext>(options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("LeaveManagementConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>) , typeof(GenericRepository <>));

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();


            return services;
        }
    }
}
