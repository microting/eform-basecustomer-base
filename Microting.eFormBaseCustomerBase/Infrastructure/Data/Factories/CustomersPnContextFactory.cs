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
            //    {"host=localhost;Database=customers-pl;Uid=root;Pwd=111111;port=3306;Convert Zero Datetime = true;SslMode=none;PersistSecurityInfo=true;"};
            //args = new[]
            //    {"Data Source=.\\SQLEXPRESS;Database=customers-pl;Integrated Security=True"};
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
