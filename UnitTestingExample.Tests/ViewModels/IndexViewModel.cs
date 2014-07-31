using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using FakeItEasy;
using UnitTestingExample.UI.Models;

namespace UnitTestingExample.Tests.ViewModels
{
    [TestClass]
    public class IndexViewModelTests
    {
        [TestMethod]
        [TestCategory("ViewModel")]
        public void Should_Return_Error_If_Value_Is_NaN()
        {
            //Arrange
            var modelState = A.Fake<ModelStateDictionary>();
            var model = new IndexViewModel() { Value= "abc"};
            int expectedErrors = 1;          
            // Act
            model.ValidateModel(modelState);

            // Assert
            Assert.AreEqual(modelState.Keys.Count, expectedErrors);
            Assert.IsTrue(modelState.Keys.Contains("Value"));
            Assert.AreEqual(modelState["Value"].Errors[0].ErrorMessage, "Please enter a number");
        }
    }
}
