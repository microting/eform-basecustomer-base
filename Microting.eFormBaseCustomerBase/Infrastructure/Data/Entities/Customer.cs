using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

// ReSharper disable InconsistentNaming

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities
{
    public class Customer : BaseEntity
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
        
        public int? CrmId { get; set; }
        
        public string CadastralNumber { get; set; }
        
        public int? PropertyNumber { get; set; }
        
        public int? ApartmentNumber { get; set; }
        
        public int? CompletionYear { get; set; }
        
        public int? FloorsWithLivingSpace { get; set; }
        
        public int? CadastralType { get; set; }

        public bool PaymentOverdue { get; set; }

        public string PaymentStatus { get; set; }

        public int Balance { get; set; }

        public int CreditLimit { get; set; }

        public async Task Create(CustomersPnDbAnySql dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.Customers.Add(this);
            await dbContext.SaveChangesAsync();

            dbContext.CustomerVersions.Add(MapVersions(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(CustomersPnDbAnySql dbContext)
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
            customer.CrmId = CrmId;
            customer.CadastralNumber = CadastralNumber;
            customer.PropertyNumber = PropertyNumber;
            customer.ApartmentNumber = ApartmentNumber;
            customer.CompletionYear = CompletionYear;
            customer.FloorsWithLivingSpace = FloorsWithLivingSpace;
            customer.CadastralType = CadastralType;

            if (dbContext.ChangeTracker.HasChanges())
            {
                customer.UpdatedAt = DateTime.Now;
                customer.Version += 1;
                await dbContext.SaveChangesAsync();

                dbContext.CustomerVersions.Add(MapVersions(customer));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(CustomersPnDbAnySql dbContext)
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
                await dbContext.SaveChangesAsync();
                
                dbContext.CustomerVersions.Add(MapVersions(customer));
                await dbContext.SaveChangesAsync();
            }
        }

        private CustomerVersion MapVersions(Customer customer)
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
                CrmId = customer.CrmId,
                CadastralNumber = customer.CadastralNumber,
                PropertyNumber = customer.PropertyNumber,
                ApartmentNumber = customer.ApartmentNumber,
                CompletionYear = customer.CompletionYear,
                FloorsWithLivingSpace = customer.FloorsWithLivingSpace,
                CadastralType = customer.CadastralType
            };
        }
    }
}