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
            Assert.That(customer, Is.Not.Null);

            Assert.That(customerList.Count(), Is.EqualTo(1));
            Assert.That(customerVersions.Count(), Is.EqualTo(1));
            
            Assert.That(customer.CityName, Is.EqualTo(newCustomer.CityName ));
            Assert.That(customer.CompanyAddress, Is.EqualTo(newCustomer.CompanyAddress ));
            Assert.That(customer.CompanyName, Is.EqualTo(newCustomer.CompanyName ));
            Assert.That(customer.CustomerNo, Is.EqualTo(newCustomer.CustomerNo ));
            Assert.That(customer.Description, Is.EqualTo(newCustomer.Description ));
            Assert.That(customer.Email, Is.EqualTo(newCustomer.Email ));
            Assert.That(customer.Phone, Is.EqualTo(newCustomer.Phone ));
            Assert.That(customer.ZipCode, Is.EqualTo(newCustomer.ZipCode ));
            Assert.That(customer.RelatedEntityId, Is.EqualTo(newCustomer.RelatedEntityId ));
            Assert.That(customer.EanCode, Is.EqualTo(newCustomer.EanCode ));
            Assert.That(customer.VatNumber, Is.EqualTo(newCustomer.VatNumber ));
            Assert.That(customer.CountryCode, Is.EqualTo(newCustomer.CountryCode ));
            Assert.That(customer.CrmId, Is.EqualTo(newCustomer.CrmId ));
            Assert.That(customer.CadastralNumber, Is.EqualTo(newCustomer.CadastralNumber ));
            Assert.That(customer.PropertyNumber, Is.EqualTo(newCustomer.PropertyNumber ));
            Assert.That(customer.ApartmentNumber, Is.EqualTo(newCustomer.ApartmentNumber ));
            Assert.That(customer.CompletionYear, Is.EqualTo(newCustomer.CompletionYear ));
            Assert.That(customer.FloorsWithLivingSpace, Is.EqualTo(newCustomer.FloorsWithLivingSpace ));
            Assert.That(customer.CompanyAddress2, Is.EqualTo(newCustomer.CompanyAddress2 ));
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
            Assert.That(dbCustomer, Is.Not.Null);

            Assert.That(customerList.Count(), Is.EqualTo(1));
            Assert.That(customerVersions.Count(), Is.EqualTo(2));

            Assert.That(dbCustomer.CityName, Is.EqualTo(newCustomer.CityName ));
            Assert.That(dbCustomer.CompanyAddress, Is.EqualTo(newCustomer.CompanyAddress ));
            Assert.That(dbCustomer.CompanyName, Is.EqualTo(newCustomer.CompanyName ));
            Assert.That(dbCustomer.CustomerNo, Is.EqualTo(newCustomer.CustomerNo ));
            Assert.That(dbCustomer.Description, Is.EqualTo(newCustomer.Description ));
            Assert.That(dbCustomer.Email, Is.EqualTo(newCustomer.Email ));
            Assert.That(dbCustomer.Phone, Is.EqualTo(newCustomer.Phone ));
            Assert.That(dbCustomer.ZipCode, Is.EqualTo(newCustomer.ZipCode ));
            Assert.That(dbCustomer.RelatedEntityId, Is.EqualTo(newCustomer.RelatedEntityId ));
            Assert.That(dbCustomer.EanCode, Is.EqualTo(newCustomer.EanCode ));
            Assert.That(dbCustomer.VatNumber, Is.EqualTo(newCustomer.VatNumber ));
            Assert.That(dbCustomer.CountryCode, Is.EqualTo(newCustomer.CountryCode ));
            Assert.That(dbCustomer.CrmId, Is.EqualTo(newCustomer.CrmId ));
            Assert.That(dbCustomer.CadastralNumber, Is.EqualTo(newCustomer.CadastralNumber ));
            Assert.That(dbCustomer.PropertyNumber, Is.EqualTo(newCustomer.PropertyNumber ));
            Assert.That(dbCustomer.ApartmentNumber, Is.EqualTo(newCustomer.ApartmentNumber ));
            Assert.That(dbCustomer.CompletionYear, Is.EqualTo(newCustomer.CompletionYear ));
            Assert.That(dbCustomer.FloorsWithLivingSpace, Is.EqualTo(newCustomer.FloorsWithLivingSpace ));
            Assert.That(dbCustomer.CompanyAddress2, Is.EqualTo(newCustomer.CompanyAddress2 ));
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
            Assert.That(dbCustomer, Is.Not.Null);

            Assert.That(customerList.Count(), Is.EqualTo(1));
            Assert.That(customerVersions.Count(), Is.EqualTo(1));

            Assert.That(dbCustomer.CityName, Is.EqualTo(newCustomer.CityName ));
            Assert.That(dbCustomer.CompanyAddress, Is.EqualTo(newCustomer.CompanyAddress ));
            Assert.That(dbCustomer.CompanyName, Is.EqualTo(newCustomer.CompanyName ));
            Assert.That(dbCustomer.CustomerNo, Is.EqualTo(newCustomer.CustomerNo ));
            Assert.That(dbCustomer.Description, Is.EqualTo(newCustomer.Description ));
            Assert.That(dbCustomer.Email, Is.EqualTo(newCustomer.Email ));
            Assert.That(dbCustomer.Phone, Is.EqualTo(newCustomer.Phone ));
            Assert.That(dbCustomer.ZipCode, Is.EqualTo(newCustomer.ZipCode ));
            Assert.That(dbCustomer.RelatedEntityId, Is.EqualTo(newCustomer.RelatedEntityId ));
            Assert.That(dbCustomer.EanCode, Is.EqualTo(newCustomer.EanCode ));
            Assert.That(dbCustomer.VatNumber, Is.EqualTo(newCustomer.VatNumber ));
            Assert.That(dbCustomer.CountryCode, Is.EqualTo(newCustomer.CountryCode ));
            Assert.That(dbCustomer.CrmId, Is.EqualTo(newCustomer.CrmId ));
            Assert.That(dbCustomer.CadastralNumber, Is.EqualTo(newCustomer.CadastralNumber ));
            Assert.That(dbCustomer.PropertyNumber, Is.EqualTo(newCustomer.PropertyNumber ));
            Assert.That(dbCustomer.ApartmentNumber, Is.EqualTo(newCustomer.ApartmentNumber ));
            Assert.That(dbCustomer.CompletionYear, Is.EqualTo(newCustomer.CompletionYear ));
            Assert.That(dbCustomer.FloorsWithLivingSpace, Is.EqualTo(newCustomer.FloorsWithLivingSpace ));
            Assert.That(dbCustomer.CompanyAddress2, Is.EqualTo(newCustomer.CompanyAddress2 ));
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
            Assert.That(dbCustomer, Is.Not.Null);

            Assert.That(customerList.Count(), Is.EqualTo(1));
            Assert.That(customerVersions.Count(), Is.EqualTo(2));

            Assert.That(dbCustomer.CityName, Is.EqualTo(customer.CityName));
            Assert.That(dbCustomer.CompanyAddress, Is.EqualTo(customer.CompanyAddress));
            Assert.That(dbCustomer.CompanyName, Is.EqualTo(customer.CompanyName));
            Assert.That(dbCustomer.ContactPerson, Is.EqualTo(customer.ContactPerson));
            Assert.That(dbCustomer.CreatedBy, Is.EqualTo(customer.CreatedBy));
            Assert.That(dbCustomer.CustomerNo, Is.EqualTo(customer.CustomerNo));
            Assert.That(dbCustomer.Description, Is.EqualTo(customer.Description));
            Assert.That(dbCustomer.Email, Is.EqualTo(customer.Email));
            Assert.That(dbCustomer.Phone, Is.EqualTo(customer.Phone));
            Assert.That(dbCustomer.ZipCode, Is.EqualTo(customer.ZipCode));
            Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(customer.WorkflowState));
        }
    }
}
