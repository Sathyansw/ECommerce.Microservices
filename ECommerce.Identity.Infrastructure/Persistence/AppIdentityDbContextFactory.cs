using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Infrastructure.Persistence
{
    public class AppIdentityDbContextFactory
        : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-KCRFKO8;Database=ECommerceIdentityDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new AppIdentityDbContext(optionsBuilder.Options);
        }
    }
}
