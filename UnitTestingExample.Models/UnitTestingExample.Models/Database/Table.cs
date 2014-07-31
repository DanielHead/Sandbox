using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingExample.Models.Database
{
    public class Table
    {
        public virtual Guid Id { get; set; }
        public virtual int TestIntOne { get; set; }
        public virtual string TestVarcharTwo { get; set; }
        public virtual DateTime TestDateField { get; set; }
    }
}
