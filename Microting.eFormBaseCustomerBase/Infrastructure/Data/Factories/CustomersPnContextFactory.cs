using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Factories
{
    public class CustomersPnContextFactory : IDesignTimeDbContextFactory<CustomersPnDbAnySql>
    {
        public CustomersPnDbAnySql CreateDbContext(string[] args)
        {
            //args = new[]
            //    {"data source=.\\sqlexpress;database=appointments-plugin;integrated security=true"};
            var optionsBuilder = new DbContextOptionsBuilder<CustomersPnDbAnySql>();
            if (args.Any())
            {
                if (args.FirstOrDefault().ToLower().Contains("convert zero datetime"))
                {
                    optionsBuilder.UseMySql(args.FirstOrDefault());
                }
                else
                {
                    optionsBuilder.UseSqlServer(args.FirstOrDefault());
                }
            }
            else
            {
                throw new ArgumentNullException("Connection string not present");
            }
//            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\SharedInstance;Initial catalog=customers-pn-tests;Integrated Security=True");
//            dotnet ef migrations add InitialCreate --project Microting.eFormBaseCustomerBase --startup-project DBMigrator
            optionsBuilder.UseLazyLoadingProxies(true);
            return new CustomersPnDbAnySql(optionsBuilder.Options);
        }
    }
}
