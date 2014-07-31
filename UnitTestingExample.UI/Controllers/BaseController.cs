using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingExample.UI.ServiceChannelFactory;

namespace UnitTestingExample.UI.Controllers
{
    public class BaseController : Controller
    {
        protected UnitTestingExampleClient Client { get; set; }

        public BaseController(UnitTestingExampleClient client)
        {
            Client = client;
        }

        public BaseController()
        {
            Client = new UnitTestingExampleClient();
        }
	}
}