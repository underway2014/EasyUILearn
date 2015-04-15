using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyUILearn.Controllers
{
    public class HomeController : Controller
    {
        //test
      [CustomFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}