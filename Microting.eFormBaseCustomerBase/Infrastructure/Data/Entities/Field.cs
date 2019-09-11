using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities
{
    public class Field : BaseEntity, IDataAccessObject<CustomersPnDbAnySql>
    {
        [StringLength(50)]
        public string Name { get; set; }

        public void Create(CustomersPnDbAnySql dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.Fields.Add(this);
            dbContext.SaveChanges();
        }

        public void Update(CustomersPnDbAnySql dbContext)
        {
            Field field = dbContext.Fields.SingleOrDefault(x => x.Id == Id);

            if (field == null)
            {
                throw new NullReferenceException($"Could not find field with id {Id}");
            }

            field.Name = Name;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dbContext.SaveChanges();
            }
        }

        public void Delete(CustomersPnDbAnySql dbContext)
        {
            Field field = dbContext.Fields.SingleOrDefault(x => x.Id == Id);

            if (field == null)
            {
                throw new NullReferenceException($"Could not find field with id {Id}");
            }

            field.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dbContext.SaveChanges();
            }
        }
    }
}