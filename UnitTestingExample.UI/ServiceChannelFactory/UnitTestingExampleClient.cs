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
        
        /// <summary>
        /// This is the proxy client which is used by the controllers.
        /// Note: all methods need to be virtual to allow mocking.
        /// </summary>
        public UnitTestingExampleClient(): base(EndpointName)
	    {
           
        }

        public virtual ExampleStatus DoSomeExampleStuff(int id) 
        {
            return Channel.DoSomeExampleStuff(id);
        }

        public virtual void DoSomethingElse()
        {
            Channel.DoSomethingElse();
        }
    }
}