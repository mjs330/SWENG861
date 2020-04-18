using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWENG861.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(string id = "index")
        {
            return View("/Views/Test/" + id.ToLower() + ".cshtml");
        }
    }
}