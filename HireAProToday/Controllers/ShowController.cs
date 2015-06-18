using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireAProToday.Controllers
{
    public class ShowController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            return View();
        }

        // GET: Show/Tickets
        public ActionResult Tickets()
        {
            return View();
        }

        // GET: Show/ExhibitorInfo
        public ActionResult ExhibitorInfo()
        {
            return View();
        }
    }
}