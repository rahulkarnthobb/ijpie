using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace IjpieSite.Controllers
{
    [Authorize]
    public class DetailViewController : Controller
    {
        // GET: DetailView
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult DeleteQCVM(int id)
        {
            using (var client = new WebClient())
            {
               client.Headers.Add("content-type", "application/json");//
                string response = client.DownloadString("http://ijpieapi.azurewebsites.net/api/VmDelete?" + id);
                if (response == "true")
                {
                    return Redirect("/DetailView/Index");

                }
                else
                {
                    return Redirect("/Dashboard/Index");
                }
            }

        }
    }
}