using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sobes_app.Models
{
    [Flags]
    public enum Options
    {
        None = 0,
        Potato = 1,
        Tomato = 2,
        Carrot = 4,
        Cabbage = 8,
        Onion = 16,
        Garlic = 32,
        Pea = 64,
        Radish = 128,
        Corn = 256,
        Pumpkin = 512
    }

    public class OptionModel
    {
        private Options options;
        private string Message;
        public OptionModel()
        {
            options = Options.None;
        }
        public OptionModel(Options options)
        {
            this.options = options;
        }
        public void Set(Options options = Options.None, string message = "")
        {
            this.options = options;
            this.Message = message;
        }
        public Options Get()
        {
           return this.options;
        }
        public string GetMessage()
        {
            return this.Message;
        }
        public override string ToString() {
            int val = (int)this.options;
            int count = 0;
            while (val > 0)
            {
                if ((val & 1) != 0)
                {
                    count++;
                }
                val = val >> 1;
            }
            if (this.options == Options.None)
                return "There are no options chosed";
            if(count==1)
                return "Chosed option is: " + options.ToString();
            else
                return "Chosed options are: " + options.ToString();
        }
    }
}