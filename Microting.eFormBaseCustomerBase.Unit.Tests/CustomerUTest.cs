using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.eFormBaseCustomerBase.Unit.Tests
{
    [TestFixture]
    public class CustomerUTest : DbTestFixture
    {
        [Test]
        public async Task CustomerFullModel_Save_DoesSave()
        {
            // Arrange
            
            Random rnd = new Random();
            
            Customer newCustomer = new Customer
            {
                CityName = Guid.NewGuid().ToString(),
                CompanyAddress = Guid.NewGuid().ToString(),
                CompanyAddress2 = Guid.NewGuid().ToString(),
                CompanyName = Guid.NewGuid().ToString(),
                ContactPerson = Guid.NewGuid().ToString(),
                CreatedBy = Guid.NewGuid().ToString(),
                CustomerNo = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString(),
                RelatedEntityId = rnd.Next(1, 255),
                EanCode = Guid.NewGuid().ToString(),
                VatNumber = Guid.NewGuid().ToString(),
                CountryCode = Guid.NewGuid().ToString(),
                CrmId = rnd.Next(1, 255),
                CadastralNumber = Guid.NewGuid().ToString(),
                PropertyNumber = rnd.Next(1, 255),
                ApartmentNumber = rnd.Next(1, 255),
                CompletionYear = rnd.Next(1, 255),
                FloorsWithLivingSpace = rnd.Next(1, 255)
            };

            // Act
            await newCustomer.Create(DbContext);

            Customer customer = DbContext.Customers.AsNoTracking().First();
            List<Customer> customerList = DbContext.Customers.AsNoTracking().ToList();
            List<CustomerVersion> customerVersions = DbContext.CustomerVersions.AsNoTracking().ToList();
            // Assert
            Assert.NotNull(customer);

            Assert.AreEqual(1, customerList.Count());
            Assert.AreEqual(1, customerVersions.Count());
            
            Assert.AreEqual(newCustomer.CityName , customer.CityName);
            Assert.AreEqual(newCustomer.CompanyAddress , customer.CompanyAddress);
            Assert.AreEqual(newCustomer.CompanyName , customer.CompanyName);
            Assert.AreEqual(newCustomer.CustomerNo , customer.CustomerNo);
            Assert.AreEqual(newCustomer.Description , customer.Description);
            Assert.AreEqual(newCustomer.Email , customer.Email);
            Assert.AreEqual(newCustomer.Phone , customer.Phone);
            Assert.AreEqual(newCustomer.ZipCode , customer.ZipCode);
            Assert.AreEqual(newCustomer.RelatedEntityId , customer.RelatedEntityId);
            Assert.AreEqual(newCustomer.EanCode , customer.EanCode);
            Assert.AreEqual(newCustomer.VatNumber , customer.VatNumber);
            Assert.AreEqual(newCustomer.CountryCode , customer.CountryCode);
            Assert.AreEqual(newCustomer.CrmId , customer.CrmId);
            Assert.AreEqual(newCustomer.CadastralNumber , customer.CadastralNumber);
            Assert.AreEqual(newCustomer.PropertyNumber , customer.PropertyNumber);
            Assert.AreEqual(newCustomer.ApartmentNumber , customer.ApartmentNumber);
            Assert.AreEqual(newCustomer.CompletionYear , customer.CompletionYear);
            Assert.AreEqual(newCustomer.FloorsWithLivingSpace , customer.FloorsWithLivingSpace);
            Assert.AreEqual(newCustomer.CompanyAddress2 , customer.CompanyAddress2);
        }
        //needs version.
        [Test]
        public async Task CustomerFullModel_Update_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();
            
            Customer newCustomer = new Customer
            {
                CityName = Guid.NewGuid().ToString(),
                CompanyAddress = Guid.NewGuid().ToString(),
                CompanyAddress2 = Guid.NewGuid().ToString(),
                CompanyName = Guid.NewGuid().ToString(),
                ContactPerson = Guid.NewGuid().ToString(),
                CreatedBy = Guid.NewGuid().ToString(),
                CustomerNo = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString(),
                RelatedEntityId = rnd.Next(1, 255),
                EanCode = Guid.NewGuid().ToString(),
                VatNumber = Guid.NewGuid().ToString(),
                CountryCode = Guid.NewGuid().ToString(),
                CrmId = rnd.Next(1, 255),
                CadastralNumber = Guid.NewGuid().ToString(),
                PropertyNumber = rnd.Next(1, 255),
                ApartmentNumber = rnd.Next(1, 255),
                CompletionYear = rnd.Next(1, 255),
                FloorsWithLivingSpace = rnd.Next(1, 255)
            };

            await newCustomer.Create(DbContext);

            // Act
            newCustomer.CityName = Guid.NewGuid().ToString();
            newCustomer.CompanyAddress = Guid.NewGuid().ToString();
            newCustomer.CompanyName = Guid.NewGuid().ToString();
            newCustomer.ContactPerson = Guid.NewGuid().ToString();
            newCustomer.CreatedBy = Guid.NewGuid().ToString();
            newCustomer.CustomerNo = Guid.NewGuid().ToString();
            newCustomer.Description = Guid.NewGuid().ToString();
            newCustomer.Email = Guid.NewGuid().ToString();
            newCustomer.Phone = Guid.NewGuid().ToString();
            newCustomer.ZipCode = Guid.NewGuid().ToString();
            newCustomer.RelatedEntityId = rnd.Next(1, 255);
            newCustomer.EanCode = Guid.NewGuid().ToString();
            newCustomer.VatNumber = Guid.NewGuid().ToString();
            newCustomer.CountryCode = Guid.NewGuid().ToString();
            newCustomer.CrmId = rnd.Next(1, 255);
            newCustomer.CadastralNumber = Guid.NewGuid().ToString();
            newCustomer.PropertyNumber = rnd.Next(1, 255);
            newCustomer.ApartmentNumber = rnd.Next(1, 255);
            newCustomer.CompletionYear = rnd.Next(1, 255);
            newCustomer.FloorsWithLivingSpace = rnd.Next(1, 255);
            
            
            await newCustomer.Update(DbContext);

            Customer dbCustomer = DbContext.Customers.AsNoTracking().First();
            List<Customer> customerList = DbContext.Customers.AsNoTracking().ToList();
            List<CustomerVersion> customerVersions = DbContext.CustomerVersions.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbCustomer);

            Assert.AreEqual(1, customerList.Count());
            Assert.AreEqual(2, customerVersions.Count());

            Assert.AreEqual(newCustomer.CityName , dbCustomer.CityName);
            Assert.AreEqual(newCustomer.CompanyAddress , dbCustomer.CompanyAddress);
            Assert.AreEqual(newCustomer.CompanyName , dbCustomer.CompanyName);
            Assert.AreEqual(newCustomer.CustomerNo , dbCustomer.CustomerNo);
            Assert.AreEqual(newCustomer.Description , dbCustomer.Description);
            Assert.AreEqual(newCustomer.Email , dbCustomer.Email);
            Assert.AreEqual(newCustomer.Phone , dbCustomer.Phone);
            Assert.AreEqual(newCustomer.ZipCode , dbCustomer.ZipCode);
            Assert.AreEqual(newCustomer.RelatedEntityId , dbCustomer.RelatedEntityId);
            Assert.AreEqual(newCustomer.EanCode , dbCustomer.EanCode);
            Assert.AreEqual(newCustomer.VatNumber , dbCustomer.VatNumber);
            Assert.AreEqual(newCustomer.CountryCode , dbCustomer.CountryCode);
            Assert.AreEqual(newCustomer.CrmId , dbCustomer.CrmId);
            Assert.AreEqual(newCustomer.CadastralNumber , dbCustomer.CadastralNumber);
            Assert.AreEqual(newCustomer.PropertyNumber , dbCustomer.PropertyNumber);
            Assert.AreEqual(newCustomer.ApartmentNumber , dbCustomer.ApartmentNumber);
            Assert.AreEqual(newCustomer.CompletionYear , dbCustomer.CompletionYear);
            Assert.AreEqual(newCustomer.FloorsWithLivingSpace , dbCustomer.FloorsWithLivingSpace);
            Assert.AreEqual(newCustomer.CompanyAddress2 , dbCustomer.CompanyAddress2);
        }
        [Test]
        public async Task CustomerFullModel_Update_DoesUpdateWithSameStrings()
        {
            // Arrange
            Random rnd = new Random();
            
            Customer newCustomer = new Customer();

            string CityName = Guid.NewGuid().ToString();
            string CompanyAddress = Guid.NewGuid().ToString();
            string CompanyAddress2 = Guid.NewGuid().ToString();
            string CompanyName = Guid.NewGuid().ToString();
            string ContactPerson = Guid.NewGuid().ToString();
            string CreatedBy = Guid.NewGuid().ToString();
            string CustomerNo = Guid.NewGuid().ToString();
            string Description = Guid.NewGuid().ToString();
            string Email = Guid.NewGuid().ToString();
            string Phone = Guid.NewGuid().ToString();
            string ZipCode = Guid.NewGuid().ToString();
            int? RelatedEntityId = rnd.Next(1, 255);
            string EANCode = Guid.NewGuid().ToString();
            string VATNumber = Guid.NewGuid().ToString();
            string CountryCode = Guid.NewGuid().ToString();
            int? CrmId = rnd.Next(1, 255);
            string CadastralNumber = Guid.NewGuid().ToString();
            int PropertyNumber = rnd.Next(1, 255);
            int ApartmentNumber = rnd.Next(1, 255);
            int CompletionYear = rnd.Next(1, 255);
            int FloorsWithLivingSpace = rnd.Next(1, 255);
            
            
            
            newCustomer.CityName = CityName;
            newCustomer.CompanyAddress = CompanyAddress;
            newCustomer.CompanyAddress2 = CompanyAddress2;
            newCustomer.CompanyName = CompanyName;
            newCustomer.ContactPerson = ContactPerson;
            newCustomer.CreatedBy = CreatedBy;
            newCustomer.CustomerNo = CustomerNo;
            newCustomer.Description = Description;
            newCustomer.Email = Email;
            newCustomer.Phone = Phone;
            newCustomer.ZipCode = ZipCode;
            newCustomer.RelatedEntityId = RelatedEntityId;
            newCustomer.EanCode = EANCode;
            newCustomer.VatNumber = VATNumber;
            newCustomer.CountryCode = CountryCode;
            newCustomer.CrmId = CrmId;
            newCustomer.CadastralNumber = CadastralNumber;
            newCustomer.PropertyNumber = PropertyNumber;
            newCustomer.ApartmentNumber = ApartmentNumber;
            newCustomer.CompletionYear = CompletionYear;
            newCustomer.FloorsWithLivingSpace = FloorsWithLivingSpace;

            await newCustomer.Create(DbContext);

            // Act
            newCustomer.CityName = CityName;
            newCustomer.CompanyAddress = CompanyAddress;
            newCustomer.CompanyAddress2 = CompanyAddress2;
            newCustomer.CompanyName = CompanyName;
            newCustomer.ContactPerson = ContactPerson;
            newCustomer.CreatedBy = CreatedBy;
            newCustomer.CustomerNo = CustomerNo;
            newCustomer.Description = Description;
            newCustomer.Email = Email;
            newCustomer.Phone = Phone;
            newCustomer.ZipCode = ZipCode;
            newCustomer.RelatedEntityId = RelatedEntityId;
            newCustomer.EanCode = EANCode;
            newCustomer.VatNumber = VATNumber;
            newCustomer.CountryCode = CountryCode;
            newCustomer.CrmId = CrmId;
            newCustomer.CadastralNumber = CadastralNumber;
            newCustomer.PropertyNumber = PropertyNumber;
            newCustomer.ApartmentNumber = ApartmentNumber;
            newCustomer.CompletionYear = CompletionYear;
            newCustomer.FloorsWithLivingSpace = FloorsWithLivingSpace;

            await newCustomer.Update(DbContext);

            Customer dbCustomer = DbContext.Customers.AsNoTracking().First();
            List<Customer> customerList = DbContext.Customers.AsNoTracking().ToList();
            List<CustomerVersion> customerVersions = DbContext.CustomerVersions.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbCustomer);

            Assert.AreEqual(1, customerList.Count());
            Assert.AreEqual(1, customerVersions.Count());

            Assert.AreEqual(newCustomer.CityName , dbCustomer.CityName);
            Assert.AreEqual(newCustomer.CompanyAddress , dbCustomer.CompanyAddress);
            Assert.AreEqual(newCustomer.CompanyName , dbCustomer.CompanyName);
            Assert.AreEqual(newCustomer.CustomerNo , dbCustomer.CustomerNo);
            Assert.AreEqual(newCustomer.Description , dbCustomer.Description);
            Assert.AreEqual(newCustomer.Email , dbCustomer.Email);
            Assert.AreEqual(newCustomer.Phone , dbCustomer.Phone);
            Assert.AreEqual(newCustomer.ZipCode , dbCustomer.ZipCode);
            Assert.AreEqual(newCustomer.RelatedEntityId , dbCustomer.RelatedEntityId);
            Assert.AreEqual(newCustomer.EanCode , dbCustomer.EanCode);
            Assert.AreEqual(newCustomer.VatNumber , dbCustomer.VatNumber);
            Assert.AreEqual(newCustomer.CountryCode , dbCustomer.CountryCode);
            Assert.AreEqual(newCustomer.CrmId , dbCustomer.CrmId);
            Assert.AreEqual(newCustomer.CadastralNumber , dbCustomer.CadastralNumber);
            Assert.AreEqual(newCustomer.PropertyNumber , dbCustomer.PropertyNumber);
            Assert.AreEqual(newCustomer.ApartmentNumber , dbCustomer.ApartmentNumber);
            Assert.AreEqual(newCustomer.CompletionYear , dbCustomer.CompletionYear);
            Assert.AreEqual(newCustomer.FloorsWithLivingSpace , dbCustomer.FloorsWithLivingSpace);
            Assert.AreEqual(newCustomer.CompanyAddress2 , dbCustomer.CompanyAddress2);
        }
        //needs versions.
        [Test]
        public async Task CustomerFullModel_Delete_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();
            
            Customer customer = new Customer
            {
                CityName = Guid.NewGuid().ToString(),
                CompanyAddress = Guid.NewGuid().ToString(),
                CompanyAddress2 = Guid.NewGuid().ToString(),
                CompanyName = Guid.NewGuid().ToString(),
                ContactPerson = Guid.NewGuid().ToString(),
                CreatedBy = Guid.NewGuid().ToString(),
                CustomerNo = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString(),
                RelatedEntityId = rnd.Next(1, 255),
                EanCode = Guid.NewGuid().ToString(),
                VatNumber = Guid.NewGuid().ToString(),
                CountryCode = Guid.NewGuid().ToString(),
                CrmId = rnd.Next(1, 255),
                CadastralNumber = Guid.NewGuid().ToString(),
                PropertyNumber = rnd.Next(1, 255),
                ApartmentNumber = rnd.Next(1, 255),
                CompletionYear = rnd.Next(1, 255),
                FloorsWithLivingSpace = rnd.Next(1, 255)
            };

            await customer.Create(DbContext);

            // Act
            await customer.Delete(DbContext);

            Customer dbCustomer = DbContext.Customers.AsNoTracking().First();
            List<Customer> customerList = DbContext.Customers.AsNoTracking().ToList();
            List<CustomerVersion> customerVersions = DbContext.CustomerVersions.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbCustomer);

            Assert.AreEqual(1, customerList.Count());
            Assert.AreEqual(2, customerVersions.Count());

            Assert.AreEqual(customer.CityName, dbCustomer.CityName);
            Assert.AreEqual(customer.CompanyAddress, dbCustomer.CompanyAddress);
            Assert.AreEqual(customer.CompanyName, dbCustomer.CompanyName);
            Assert.AreEqual(customer.ContactPerson, dbCustomer.ContactPerson);
            Assert.AreEqual(customer.CreatedBy, dbCustomer.CreatedBy);
            Assert.AreEqual(customer.CustomerNo, dbCustomer.CustomerNo);
            Assert.AreEqual(customer.Description, dbCustomer.Description);
            Assert.AreEqual(customer.Email, dbCustomer.Email);
            Assert.AreEqual(customer.Phone, dbCustomer.Phone);
            Assert.AreEqual(customer.ZipCode, dbCustomer.ZipCode);
            Assert.AreEqual(customer.WorkflowState, Constants.WorkflowStates.Removed);
        }
    }
}
