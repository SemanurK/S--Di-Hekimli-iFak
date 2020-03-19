using Staj_DisHekimligi.Entitiy;
using Staj_DisHekimligi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_DisHekimligi.Controllers
{
    public class LoginController : Controller
    {
        Entities db = new Entities();

        // GET: Login
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Giris_Yap(Kul_Cihaz kc)
        {
            var gelen = db.KULLANICI.Where(m => m.KUL_AD.Equals(kc.kul_ad) && m.KUL_SIFRE.Equals(kc.sifre)).FirstOrDefault();
            if(gelen != null)
            {
                ViewBag.Ad_Soyad = gelen.AD_SOYAD;

                    return RedirectToAction("Index", "Cihaz");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı ve şifre uyuşmuyor";
            }
            return View("Index");
        }
        public ActionResult Icerik()
        {
            return View();
        }
    }
}