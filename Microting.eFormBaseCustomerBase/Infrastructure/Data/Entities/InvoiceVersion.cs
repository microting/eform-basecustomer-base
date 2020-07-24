using System;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities
{
    public class InvoiceVersion : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Currency { get; set; }
        public int Date { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime GrossAmount { get; set; }
        public int NetAmount { get; set; }
        public int OrderId { get; set; }
        public string Pdf { get; set; }
        public int VatAmount { get; set; }
        public int Remainder { get; set; }
        public int RemainderBaseCurrency { get; set; }
        public bool VatIncluded { get; set; }
        public int PageNo { get; set; }
        public int ApiId { get; set; }
        public int InvoiceId { get; set; }
    }
}