using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sobes_app.Models;

namespace sobes_app.Infrastructure
{
    //Start with class
    public class OptionModelBinder : DefaultModelBinder
    {
        private readonly string _typeNameKey;

        public OptionModelBinder(string typeNameKey = null)
        {
            _typeNameKey = typeNameKey ?? "__type__";
        }

        public override object BindModel
          (
            ControllerContext controllerContext,
            ModelBindingContext bindingContext
          )
        {
            Type type = bindingContext.ModelType;
            var result =  base.BindModel(controllerContext, bindingContext);
            var props = type.GetProperties();
            foreach(var prop in props) { 
                if(prop.PropertyType.BaseType == typeof(Enum) && Attribute.IsDefined(prop.PropertyType, typeof(FlagsAttribute)))
                {
                    var enumProp = Activator.CreateInstance(prop.PropertyType);
                    foreach (var option in Enum.GetValues(prop.PropertyType))
                    {
                        if (GetValue(bindingContext, option.ToString()) == "on")

                            enumProp = (int)enumProp | (int)option;
                    }
                    prop.SetValue(result, enumProp);
                }
            }
            return result;
        }

        private string GetValue(
          ModelBindingContext bindingContext, string key)
        {
            var result = bindingContext.ValueProvider.GetValue(key);
            return (result == null) ? null : result.AttemptedValue;
        }
    }
}