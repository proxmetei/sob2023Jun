using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sobes_app.Models;

namespace sobes_app.Repositories.OptionRepos
{
    public interface IOptionRepository
    {
        OptionModel Set(Options options, string message);
        OptionModel Get();
        string GetChoiceStr();
    }
}
