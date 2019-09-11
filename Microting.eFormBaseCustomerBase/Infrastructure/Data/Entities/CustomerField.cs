using System;
using System.Collections.Generic;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eFormBaseCustomerBase.Infrastructure.Models;
using Microting.eFormBaseCustomerBase.Infrastructure.Models.Fields;

namespace Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities
{
    public class CustomerField : BaseEntity, IDataAccessObject<CustomersPnDbAnySql>
    {
        public int FieldId { get; set; }
        public virtual Field Field { get; set; }

        public short? FieldStatus { get; set; }
        
        public int DisplayIndex { get; set; }

        public void Create(CustomersPnDbAnySql dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.CustomerFields.Add(this);
            dbContext.SaveChanges();
        }

        public void Update(CustomersPnDbAnySql dbContext)
        {
            CustomerField customerField = dbContext.CustomerFields.SingleOrDefault(x => x.Id == Id);

            if (customerField == null)
            {
                throw new NullReferenceException($"Could not find customerField with id {Id}");
            }

            customerField.FieldId = FieldId;
            customerField.DisplayIndex = DisplayIndex;
            customerField.FieldStatus = FieldStatus;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dbContext.SaveChanges();
            }
        }

        public void Delete(CustomersPnDbAnySql dbContext)
        {
            CustomerField customerField = dbContext.CustomerFields.SingleOrDefault(x => x.Id == Id);

            if (customerField == null)
            {
                throw new NullReferenceException($"Could not find customerField with id {Id}");
            }

            customerField.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dbContext.SaveChanges();
            }
        }

//        public void UpdateFields(CustomersPnDbAnySql dbContext, FieldsUpdateModel fieldsUpdate, List<CustomerField> customerFields)
//        {
//            foreach (CustomerField field in customerFields)// Itterating through a list of customerFields.
//            {
//                FieldUpdateModel fieldModel = fieldsUpdate.Fields.FirstOrDefault(x => x.Id == field.FieldId); // takes field from list of fields
//                if (fieldModel != null) 
//                {
//                    field.FieldStatus = fieldModel.FieldStatus;// sets new status for field, based on the updatemodels status.
//                }
//            }
//
//            dbContext.SaveChanges();
//        }
    }
}