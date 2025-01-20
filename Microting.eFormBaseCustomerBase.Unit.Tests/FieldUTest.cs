using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormBaseCustomerBase.Infrastructure.Data.Entities;
using Microting.eFormBaseCustomerBase.Infrastructure.Models;
using Microting.eFormBaseCustomerBase.Infrastructure.Models.Fields;
using NUnit.Framework;

namespace Microting.eFormBaseCustomerBase.Unit.Tests
{
    [TestFixture]
    public class FieldUTest : DbTestFixture
    {
        [Test]
        public void FieldModel_Save_DoesSave()
        {
            // Arrange
            Field newField = new Field()
            {
                Name = Guid.NewGuid().ToString()
            };

            // Act
            newField.Create(DbContext);

            Field dbField = DbContext.Fields.AsNoTracking().First();
            List<Field> fieldList = DbContext.Fields.AsNoTracking().ToList();
            // Assert

            Assert.That(dbField, Is.Not.Null);

            Assert.That(fieldList.Count(), Is.EqualTo(1));

            Assert.That(dbField.Name, Is.EqualTo(newField.Name));
            
        }
        [Test]
        public void FieldUpdateModel_Update_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();
            Field newField = new Field
            {
                Name = Guid.NewGuid().ToString()
            };

            newField.Create(DbContext);

            // Act
            FieldUpdateModel fieldUpdateModel = new FieldUpdateModel();
            fieldUpdateModel.Name = newField.Name;

            List<FieldUpdateModel> list = new List<FieldUpdateModel>();
            list.Add(fieldUpdateModel);

            FieldsUpdateModel fieldsUpdate = new FieldsUpdateModel();
            fieldsUpdate.Fields = list;

            newField.Update(DbContext);

            Field dbField = DbContext.Fields.AsNoTracking().First();
            List<Field> fieldList = DbContext.Fields.AsNoTracking().ToList();
            // Assert
            Assert.That(dbField, Is.Not.Null);

            Assert.That(fieldList.Count(), Is.EqualTo(1));

            Assert.That(dbField.Name, Is.EqualTo(fieldUpdateModel.Name));
        }

        [Test]
        public void Field_Delete_DoesDelete()
        {
            // Arrange
            Field newField = new Field()
            {
                Name = Guid.NewGuid().ToString()
            };
            newField.Create(DbContext);

            // Act

            newField.Delete(DbContext);
            Field dbField = DbContext.Fields.AsNoTracking().First();
            List<Field> fieldList = DbContext.Fields.AsNoTracking().ToList();
            List<Field> fieldVersionList = DbContext.Fields.AsNoTracking().ToList();
            // Assert

            Assert.That(dbField, Is.Not.Null);
            Assert.That(fieldVersionList, Is.Not.Null);
            
            Assert.That(fieldList.Count(), Is.EqualTo(1));
            
            Assert.That(dbField.Name, Is.EqualTo(newField.Name));
            Assert.That(dbField.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        }
    }
}
