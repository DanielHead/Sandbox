using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingExample.IServices.C;
using UnitTestingExample.Models;

namespace UnitTestingExample.UI.ServiceChannelFactory
{
    public class UnitTestingExampleClient : ServiceProxyBase<IExampleService>
    {
        const string EndpointName = "BasicHttpBinding_IExampleService";
        
        public UnitTestingExampleClient(): base(EndpointName)
	    {
           
        }

        public virtual ExampleStatus DoSomeExampleStuff(int id) // Needs to be virtual so it can be mocked
        {
            return Channel.DoSomeExampleStuff(id);
        }

        public virtual void DoSomethingElse() // Needs to be virtual so it can be mocked
        {
            Channel.DoSomethingElse();
        }
    }
}