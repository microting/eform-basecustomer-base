using System;
using System.ComponentModel.DataAnnotations;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

// ReSharper disable InconsistentNaming

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities
{
    public class CustomerVersion : BaseEntity
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

        public int CustomerId { get; set; }
        
        public string EanCode { get; set; }
        
        public string VatNumber { get; set; }
    }
}