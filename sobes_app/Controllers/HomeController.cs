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
        public ActionResult Index(Options options = Options.None)
        {
            ViewBag.Options = repository.Set(options);
            ViewBag.Message = repository.GetChoiceStr();
            return View();
        }
    }
}