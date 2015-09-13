using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspireAppsWebApiViews.Controllers
{
    public class SurveyController : Controller
    {
        public AdacitySurveyController APIController
        {
            get
            {
                return new AdacitySurveyController();
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var result = APIController.GetSurveys();
            return View(result);
        }
    }
}
