using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingExample.IServices.C;
using UnitTestingExample.Models;
using UnitTestingExample.UI.Models;
using UnitTestingExample.UI.ServiceChannelFactory;

namespace UnitTestingExample.UI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UnitTestingExampleClient client) : base(client)
        {

        }
        public HomeController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel viewModel)
        {
            viewModel.ValidateModel(ModelState);

            if (ModelState.IsValid)
            {
                using (var client = Client)
                {
                    var result = client.DoSomeExampleStuff(int.Parse(viewModel.Value));

                    switch (result)
                    {
                        case ExampleStatus.StatusOne:
                            Session["Result"] = result;
                            return RedirectToAction("Result","Home");
                        case ExampleStatus.StatusTwo:
                            ModelState.AddModelError("Error", "The details you have entered are incorrect");
                            return View("Index");
                        case ExampleStatus.StatusThree:
                             Session["Result"] = result;
                            return RedirectToAction("Result","Home");
                        case ExampleStatus.StatusFour:
                            return RedirectToAction("Error", "Home");
                    }
                }
            }

            return View();
        }

        public ActionResult Result()
        {
            
            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Error page";

            return View();
        }
    }
}