using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireAProToday.Controllers
{
    public class DirectoryController : Controller
    {
        // GET: Directory
        public ActionResult Index()
        {
            return View();
        }

        // GET: Directory/Detail
        public ActionResult Detail()
        {
            return View();
        }
    }
}