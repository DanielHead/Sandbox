using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UnitTestingExample.IServices.C;
using UnitTestingExample.Models;

namespace UnitTestingExample.Services.C
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ExampleService : IExampleService
    {
        public ExampleStatus DoSomeExampleStuff(int id)
        {
            switch (id)
            {
                case 1:
                    return ExampleStatus.StatusOne;
                case 2:
                    return ExampleStatus.StatusTwo;
                case 3:
                    return ExampleStatus.StatusThree;
                case 4:
                    return ExampleStatus.StatusFour;
                default:
                    return ExampleStatus.StatusFour;
            }
            
        }

        public void DoSomethingElse()
        { 
            //Blah
        }
    }
}
