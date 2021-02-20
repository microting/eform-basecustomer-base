using NUnit.Framework;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microting.eFormBaseCustomerBase.Infrastructure.Data;
using Microting.eFormBaseCustomerBase.Infrastructure.Data.Factories;

namespace Microting.eFormBaseCustomerBase.Unit.Tests
{
    [TestFixture]
    public abstract class DbTestFixture
    {
        protected CustomersPnDbAnySql DbContext;
        protected string ConnectionString;

        public void GetContext(string connectionStr)
        {
            CustomersPnContextFactory contextFactory = new CustomersPnContextFactory();
            DbContext = contextFactory.CreateDbContext(new[] {connectionStr});

            DbContext.Database.Migrate();
            DbContext.Database.EnsureCreated();
        }

        [SetUp]
        public void Setup()
        {
            ConnectionString = @"Server = localhost; port = 3306; Database = customers-pn-tests; user = root; password = secretpassword; Convert Zero Datetime = true;";

            GetContext(ConnectionString);

            DbContext.Database.SetCommandTimeout(300);

            try
            {
                ClearDb();
            }
            catch
            {
                DbContext.Database.Migrate();
            }

            DoSetup();
        }

        [TearDown]
        public void TearDown()
        {

            ClearDb();

            ClearFile();

            DbContext.Dispose();
        }

        public void ClearDb()
        {
            List<string> modelNames = new List<string>
            {
                "CustomerVersions",
                "Customers",
                "CustomerFields",
                "CustomerSettings",
                "Fields"
            };

            bool firstRunNotDone = true;

            foreach (var modelName in modelNames)
            {
                try
                {
                    if (firstRunNotDone)
                    {
                        DbContext.Database.ExecuteSqlRaw(
                            $"SET FOREIGN_KEY_CHECKS = 0;TRUNCATE `customers-pn-tests`.`{modelName}`");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Unknown database 'customers-pn-tests'")
                    {
                        firstRunNotDone = false;
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        private string _path;

        public void ClearFile()
        {
            _path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _path = Path.GetDirectoryName(_path)?.Replace(@"file:\", "");

            string picturePath = _path + @"\output\dataFolder\picture\Deleted";

            DirectoryInfo diPic = new DirectoryInfo(picturePath);

            try
            {
                foreach (FileInfo file in diPic.GetFiles())
                {
                    file.Delete();
                }
            }
            catch
            {
                // ignored
            }
        }
        public virtual void DoSetup() { }

    }
}
