using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingExample.UI.Controllers;
using UnitTestingExample.UI.Models;
using FakeItEasy;
using System.Web.Mvc;
using UnitTestingExample.Models;
using System.Web;
using UnitTestingExample.UI;
using UnitTestingExample.UI.ServiceChannelFactory;

namespace UnitTestingExample.Tests.Controllers
{
    [TestClass]             
    public class HomeControllerTests
    {
        [TestMethod]
        [TestCategory("Controller")]
        public void HomeController_IndexAction_Post_Should_ReturnCorrectActionResult_When_StatusOfOneIsReturnedFromService()
        {
            //Arrange
            var model = A.Fake<IndexViewModel>();
            model.Value = "0";

            A.CallTo(() => model.ValidateModel(A<ModelStateDictionary>._)).DoesNothing();

            var service = A.Fake<UnitTestingExampleClient>();
            A.CallTo(() => service.DoSomeExampleStuff(A<int>._)).Returns(ExampleStatus.StatusOne);

            var controllerContext = A.Fake<ControllerContext>();
            
            var controller = new HomeController(service);
            controller.ControllerContext = controllerContext;

            // Act
            var result = controller.Index(model) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Result");
            Assert.AreEqual(result.RouteValues["controller"], "Home");
        }

        [TestMethod]
        [TestCategory("Controller")]
        public void HomeController_IndexAction_Post_Should_ReturnCorrectViewAndInvalidModelState_When_StatusOfOneIsReturnedFromService()
        {
            //Arrange
            var model = A.Fake<IndexViewModel>();
            model.Value = "0";

            A.CallTo(() => model.ValidateModel(A<ModelStateDictionary>._)).DoesNothing();

            var service = A.Fake<UnitTestingExampleClient>();
            A.CallTo(() => service.DoSomeExampleStuff(A<int>._)).Returns(ExampleStatus.StatusTwo);

            var controllerContext = A.Fake<ControllerContext>();

            var controller = new HomeController(service);
            controller.ControllerContext = controllerContext;

            // Act
            var result = controller.Index(model) as ViewResult;
            
            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.AreEqual(result.ViewName, "Index");                       
        }
    }
}
