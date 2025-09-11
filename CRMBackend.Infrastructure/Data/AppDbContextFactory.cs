using CRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMBackend.Infrastructure.Data
{
    public static class AppDbContextFactory
    {
        public static void AddAppDatabase(this IServiceCollection services, string? connectionString)
        {


            // Use SQL Server (production)
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

        }
    }
}
