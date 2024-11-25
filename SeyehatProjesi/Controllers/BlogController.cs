using SeyehatProjesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeyehatProjesi.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        SeyehatProjesi.Models.Siniflar.Context c = new SeyehatProjesi.Models.Siniflar.Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var deger = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            //by.Deger3 = c.Blogs.Take(5);
            by.Deger3 = c.Blogs.ToList();
            by.Deger2 = c.Yorumlars.Take(5);
            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {
            //var BlogBul = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1= c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogId == id).ToList();
            by.Deger3 = c.Blogs.ToList();

            
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.BlogID = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }

        
        
    }
}