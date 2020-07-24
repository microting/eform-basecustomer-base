using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities
{
    public class Invoice : BaseEntity
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

        public async Task Create(CustomersPnDbAnySql dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.Invoices.Add(this);
            await dbContext.SaveChangesAsync();

            dbContext.InvoiceVersions.Add(MapVersions(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(CustomersPnDbAnySql dbContext)
        {
            Invoice invoice = dbContext.Invoices.FirstOrDefault(x => x.Id == Id);

            if (invoice == null)
            {
                throw new NullReferenceException($"Could not find Invoice with {Id}");
            }

            invoice.CustomerId = CustomerId;
            invoice.Currency = Currency;
            invoice.Date = Date;
            invoice.DueDate = DueDate;
            invoice.GrossAmount = GrossAmount;
            invoice.NetAmount = NetAmount;
            invoice.OrderId = OrderId;
            invoice.Pdf = Pdf;
            invoice.VatAmount = VatAmount;
            invoice.Remainder = Remainder;
            invoice.RemainderBaseCurrency = RemainderBaseCurrency;
            invoice.VatIncluded = VatIncluded;
            invoice.PageNo = PageNo;
            invoice.ApiId = ApiId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                invoice.UpdatedAt = DateTime.Now;
                invoice.Version += 1;
                await dbContext.SaveChangesAsync();

                dbContext.InvoiceVersions.Add(MapVersions(invoice));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(CustomersPnDbAnySql dbContext)
        {
            Invoice invoice = dbContext.Invoices.FirstOrDefault(x => x.Id == Id);

            if (invoice == null)
            {
                throw new NullReferenceException($"Could not find Invoice with {Id}");
            }

            invoice.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                invoice.UpdatedAt = DateTime.Now;
                invoice.Version += 1;
                await dbContext.SaveChangesAsync();

                dbContext.InvoiceVersions.Add(MapVersions(invoice));
                await dbContext.SaveChangesAsync();
            }
        }

        private InvoiceVersion MapVersions(Invoice invoice)
        {
            return new InvoiceVersion()
            {
                CustomerId = invoice.CustomerId,
                Currency = invoice.Currency,
                Date = invoice.Date,
                DueDate = invoice.DueDate,
                GrossAmount = invoice.GrossAmount,
                NetAmount = invoice.NetAmount,
                OrderId = invoice.OrderId,
                Pdf = invoice.Pdf,
                VatAmount = invoice.VatAmount,
                Remainder = invoice.Remainder,
                RemainderBaseCurrency = invoice.RemainderBaseCurrency,
                VatIncluded = invoice.VatIncluded,
                PageNo = invoice.PageNo,
                ApiId = invoice.ApiId,
                InvoiceId = invoice.Id,
                CreatedAt = invoice.CreatedAt,
                UpdatedAt = invoice.UpdatedAt,
                CreatedByUserId = invoice.CreatedByUserId,
                UpdatedByUserId = invoice.UpdatedByUserId,
                WorkflowState = invoice.WorkflowState,
                Version = invoice.Version
            };
        }
    }
}
