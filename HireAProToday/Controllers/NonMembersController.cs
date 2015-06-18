using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireAProToday.Controllers
{
    public class NonMembersController : Controller
    {
        // GET: NonMembers
        public ActionResult Index()
        {
            return View();
        }
    }
}