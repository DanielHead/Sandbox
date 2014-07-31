using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UnitTestingExample.Models;

namespace UnitTestingExample.IServices.C
{
    [ServiceContract]
    public interface IExampleService
    {
        [OperationContract]
        ExampleStatus DoSomeExampleStuff(int id);

        [OperationContract]
        void DoSomethingElse();
    }
}
