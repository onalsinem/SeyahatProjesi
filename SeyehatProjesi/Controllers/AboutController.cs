using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using SeyehatProjesi.Models.Siniflar;

namespace SeyehatProjesi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        SeyehatProjesi.Models.Siniflar.Context c = new SeyehatProjesi.Models.Siniflar.Context();
        public ActionResult Index()
        {
            var deger = c.Hakkimizdas.ToList();
            return View(deger);
        }
    }
}