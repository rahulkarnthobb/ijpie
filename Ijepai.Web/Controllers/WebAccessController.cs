using ijpie.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ijpie.Web.Controllers
{
    public class WebAccessController : Controller
    {
        // GET: WebAccess
        public ActionResult Index(string accessToken)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var machine = db.WebAccesses.Where(l => l.AccessToken == accessToken).FirstOrDefault();
            return View(machine);
        }
    }
}