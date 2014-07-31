using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingExample.DAL;
using UnitTestingExample.Models.Database;
using FluentNHibernate.Testing;
using System.Data;

namespace UnitTestingExample.Tests.Repository
{
    [TestClass]
    public class ExampleRepositoryTests
    {
        [TestMethod]
        [TestCategory("Repository")]
        public void CanCorrectlyMapToTable()
        {
            using (var session = ExampleRepository.CreateSessionFactory().OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                        new PersistenceSpecification<Table>(session)
                        .CheckProperty(c => c.TestIntOne, 123)
                        .CheckProperty(c => c.TestVarcharTwo, "Doe")
                        .CheckProperty(c => c.TestDateField, new DateTime(2014,07,23))
                        .VerifyTheMappings();

                    transaction.Rollback();
                }           
            }
        }
    }
}
