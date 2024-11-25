using SeyehatProjesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeyehatProjesi.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            by.Deger1 = c.Blogs.ToList();
            return View(by);
        }

        public PartialViewResult Partial1()
        {
            by.Deger1 = c.Blogs.Take(10).ToList();
            return PartialView(by);
        }

        public PartialViewResult Partial2()
        {
            by.Deger1 = c.Blogs.ToList();
            return PartialView(by);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}