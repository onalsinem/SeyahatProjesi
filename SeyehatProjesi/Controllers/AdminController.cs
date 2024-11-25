using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using SeyehatProjesi.Models.Siniflar;

namespace SeyehatProjesi.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        Blog b = new Blog();
        [Authorize]
        public ActionResult Index()
        {
            by.Deger1 = c.Blogs.ToList();
            return View(by);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            b.Tarih = b.Tarih == default(DateTime) ? DateTime.Now : b.Tarih;
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteBlog(int id)
        {
            var deger = c.Blogs.FirstOrDefault(x => x.ID == id);

            if (deger != null)
            {
                c.Blogs.Remove(deger);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BlogGetir(int id)
        {
            var deger = c.Blogs.Find(id);
            return View("BlogGetir", deger);
        }

        [HttpPost]
        public ActionResult BlogGuncelle(Blog blog)
        {
            var blg = c.Blogs.FirstOrDefault(x => x.ID == blog.ID);
            if (blg != null)
            {
                blg.Aciklama = blog.Aciklama;
                blg.Baslik = blog.Baslik;
                blg.BlogImage = blog.BlogImage;
                blg.Tarih = blog.Tarih == default(DateTime) || blog.Tarih < new DateTime(1753, 1, 1)
                    ? DateTime.Now
                    : blog.Tarih;

                c.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YorumListesi()
        {
            var yr = c.Yorumlars.ToList();
            return View(yr);
        }

        [HttpPost]
        public JsonResult YorumSil(int id)
        {
            try
            {
                var bilgi = c.Yorumlars.FirstOrDefault(x => x.ID == id);
                if (bilgi != null)
                {
                    c.Yorumlars.Remove(bilgi);
                    c.SaveChanges();
                    return Json(new { success = true, message = "Yorum başarıyla silindi." });
                }
                return Json(new { success = false, message = "Silinecek yorum bulunamadı." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        [HttpGet]
        public ActionResult YorumDetay(int id)
        {
            var yorum = c.Yorumlars.FirstOrDefault(x => x.ID == id);
            if (yorum == null)
            {
                return HttpNotFound("Yorum bulunamadı.");
            }
            return View(yorum);
        }


        [HttpPost]
        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var yr = c.Yorumlars.FirstOrDefault(x => x.ID == yorumlar.ID);
            if (yr == null)
            {
                return HttpNotFound("Yorum bulunamadı.");
            }

            yr.KullaniciAdi = yorumlar.KullaniciAdi;
            yr.Yorum = yorumlar.Yorum;
            yr.Mail = yorumlar.Mail;
            yr.BlogId = yorumlar.BlogId;

            c.SaveChanges();

            return RedirectToAction("YorumListesi", "Admin");
        }
        



    }
}