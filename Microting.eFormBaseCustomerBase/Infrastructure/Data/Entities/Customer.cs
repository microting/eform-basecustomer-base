using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

// ReSharper disable InconsistentNaming

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities
{
    public class Customer : BaseEntity, IDataAccessObject<CustomersPnDbAnySql>
    {

        public DateTime CreatedDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }
        
        public string CustomerNo { get; set; }
        
        [StringLength(250)]
        public string CompanyName { get; set; }
        
        [StringLength(250)]
        public string CompanyAddress { get; set; }
        
        [StringLength(250)]
        public string CompanyAddress2 { get; set; }
        
        [StringLength(50)]
        public string ZipCode { get; set; }
        
        [StringLength(250)]
        public string CityName { get; set; }
        
        [StringLength(250)]
        public string Phone { get; set; }
        
        [StringLength(250)]
        public string Email { get; set; }
        
        [StringLength(250)]
        public string ContactPerson { get; set; }
        
        public string Description { get; set; }
        
        public int? RelatedEntityId { get; set; }
        
        public string EanCode { get; set; }
        
        public string VatNumber { get; set; }
        
        public string CountryCode { get; set; }

        public void Create(CustomersPnDbAnySql dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.Customers.Add(this);
            dbContext.SaveChanges();

            dbContext.CustomerVersions.Add(MapCustomerVersions(dbContext, this));
            dbContext.SaveChanges();
        }

        public void Update(CustomersPnDbAnySql dbContext)
        {
            Customer customer = dbContext.Customers.FirstOrDefault(x => x.Id == Id);

            if (customer == null)
            {
                throw new NullReferenceException($"Could not find Customer with {Id}");
            }

            customer.CityName = CityName;
            customer.CompanyAddress = CompanyAddress;
            customer.CompanyAddress2 = CompanyAddress2;
            customer.CompanyName = CompanyName;
            customer.ContactPerson = ContactPerson;
            customer.CustomerNo = CustomerNo;
            customer.Description = Description;
            customer.Email = Email;
            customer.Phone = Phone;
            customer.ZipCode = ZipCode;
            customer.RelatedEntityId = RelatedEntityId;
            customer.WorkflowState = WorkflowState;
            customer.EanCode = EanCode;
            customer.VatNumber = VatNumber;
            customer.CreatedBy = CreatedBy;
            customer.CreatedDate = CreatedDate;
            customer.CountryCode = CountryCode;

            if (dbContext.ChangeTracker.HasChanges())
            {
                customer.UpdatedAt = DateTime.Now;
                customer.Version += 1;
                dbContext.SaveChanges();

                dbContext.CustomerVersions.Add(MapCustomerVersions(dbContext, customer));
                dbContext.SaveChanges();
            }
        }

        public void Delete(CustomersPnDbAnySql dbContext)
        {
            Customer customer = dbContext.Customers.FirstOrDefault(x => x.Id == Id);

            if (customer == null)
            {
                throw new NullReferenceException($"Could not find Customer with {Id}");
            }

            customer.WorkflowState = Constants.WorkflowStates.Removed;
            customer.RelatedEntityId = null;

            if (dbContext.ChangeTracker.HasChanges())
            {
                customer.UpdatedAt = DateTime.Now;
                customer.Version += 1;
                dbContext.SaveChanges();
                
                dbContext.CustomerVersions.Add(MapCustomerVersions(dbContext, customer));
                dbContext.SaveChanges();
            }
        }

        private CustomerVersion MapCustomerVersions(CustomersPnDbAnySql dbContext, Customer customer)
        {
            return new CustomerVersion()
            {
                CityName = customer.CityName,
                CompanyAddress = customer.CompanyAddress,
                CompanyAddress2 = customer.CompanyAddress2,
                CompanyName = customer.CompanyName,
                ContactPerson = customer.ContactPerson,
                CustomerNo = customer.CustomerNo,
                Description = customer.Description,
                Email = customer.Email,
                Phone = customer.Phone,
                ZipCode = customer.ZipCode,
                CustomerId = customer.Id,
                RelatedEntityId = customer.RelatedEntityId,
                WorkflowState = customer.WorkflowState,
                EanCode = customer.EanCode,
                VatNumber = customer.VatNumber,
                CountryCode = customer.CountryCode,
                CreatedBy = customer.CreatedBy,
                CreatedDate = customer.CreatedDate,
                CreatedAt = customer.CreatedAt,
                CreatedByUserId = customer.CreatedByUserId,
                UpdatedAt = customer.UpdatedAt,
                UpdatedByUserId = customer.UpdatedByUserId,
            };
        }
    }
}