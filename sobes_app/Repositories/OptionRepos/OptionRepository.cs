using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sobes_app.Models;

namespace sobes_app.Repositories.OptionRepos
{
    public class OptionRepository: IOptionRepository
    {
        private OptionModel model = new OptionModel();

        public OptionModel Get() {
            return this.model;
        }
        public OptionModel Set(Options options, string message = "")
        {
            this.model.Set(options, message);
            return this.model;
        }
        public string GetChoiceStr()
        {
            return this.model.ToString();
        }
    }
}