using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Factories
{
    public class CustomersPnContextFactory : IDesignTimeDbContextFactory<CustomersPnDbAnySql>
    {
        public CustomersPnDbAnySql CreateDbContext(string[] args)
        {
            var defaultCs = "Server = localhost; port = 3306; Database = customers-pn; user = root; Convert Zero Datetime = true;";
            var optionsBuilder = new DbContextOptionsBuilder<CustomersPnDbAnySql>();
            optionsBuilder.UseMySql(args.Any() ? args[0] : defaultCs, mysqlOptions =>
            {
                mysqlOptions.ServerVersion(new Version(10, 4, 0), ServerType.MariaDb);
            });
            optionsBuilder.UseLazyLoadingProxies(true);

            return new CustomersPnDbAnySql(optionsBuilder.Options);
            // dotnet ef migrations add InitialMigration --project Microting.eFormBaseCustomerBase --startup-project DBMigrator
        }
    }
}
