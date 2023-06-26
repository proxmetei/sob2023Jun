using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sobes_app.Models;

namespace sobes_app.Infrastructure
{
    public class OptionModelBinder : IModelBinder
    {
        public object BindModel
          (
            ControllerContext controllerContext,
            ModelBindingContext bindingContext
          )
        {
            var options = new Options();
            List<string> opt = new List<string>(); 
            foreach (var option in Enum.GetValues(typeof(sobes_app.Models.Options)))
            {
                if (GetValue(bindingContext, option.ToString()) != null)
                    options = options | (Options)option;
            }
            return options;
        }

        private string GetValue(
          ModelBindingContext bindingContext, string key)
        {
            var result = bindingContext.ValueProvider.GetValue(key);
            return (result == null) ? null : result.AttemptedValue;
        }
    }
}