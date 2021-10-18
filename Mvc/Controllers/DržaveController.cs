using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class DržaveController : Controller
    {
        // GET: Države
        public ActionResult Index()
        {
            return View();
        }
    }
}