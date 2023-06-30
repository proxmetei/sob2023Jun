using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sobes_app.Models;
using sobes_app.Repositories.OptionRepos;

namespace sobes_app.Controllers
{
    public class HomeController : Controller
    {
        private IOptionRepository repository;
        public HomeController(IOptionRepository _repository)
        {
            repository = _repository;
        }
        public ActionResult Index(OptionsViewModel viewModel = null)
        {
            Options options = viewModel == null ? Options.None : viewModel.options;
            var model = repository.Set(options, viewModel==null? "":viewModel.Message);
            ViewBag.Options = model.Get();
            ViewBag.Mes = model.GetMessage();
            ViewBag.Message = repository.GetChoiceStr();
            return View();
        }
    }
}