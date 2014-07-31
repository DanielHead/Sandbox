using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace UnitTestingExample.UI.Models
{
    public class IndexViewModel
    {
        public string Value { get; set; }

        public virtual void ValidateModel(ModelStateDictionary ModelState)
        {
            if (string.IsNullOrEmpty(Value))
            {
                ModelState.AddModelError("Value", "Please enter a value");
            }
            else
            {
                int intValue;
                if (!int.TryParse(Value, out intValue))
                {
                    ModelState.AddModelError("Value", "Please enter a number");
                }
                else
                {
                    if (int.Parse(Value) < 1 || int.Parse(Value) > 4)
                    {
                        ModelState.AddModelError("Value", "Please enter a value between 1 and 4");
                    }
                }
            }


        }
    }
}
