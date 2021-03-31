using EMS.DAL.Interface;
using EMS.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BAL
{
    public static class Helper
    {
        public static void Configure(ref IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
