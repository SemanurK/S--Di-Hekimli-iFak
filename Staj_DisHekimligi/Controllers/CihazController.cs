using Staj_DisHekimligi.Entitiy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_DisHekimligi.Controllers
{
    public class CihazController : Controller
    {
        Entities db = new Entities();
        // GET: Cihaz
        public ActionResult Index()
        {
            var model = db.CIHAZ.ToList();
            ViewBag.cihazlist = model;
            return View(model);
        }
        public ActionResult Guncelle(int id)
        {
            var cihaz = db.CIHAZ.FirstOrDefault(x => x.CIHAZ_ID == id);
            return View(cihaz);

        }
        public ActionResult Sil(int id)
        {
            var cihaz = db.CIHAZ.Find(id);
            if(cihaz!=null)
            {
                db.CIHAZ.Remove(cihaz);
                db.SaveChanges();
            }
            return View("Index", db.CIHAZ.ToList());

        }

        [HttpPost]
        public ActionResult Guncelle(CIHAZ cihaz)
        {
           
            if (cihaz.CIHAZ_ID == 0)//ekleme işlemi
            {
                db.CIHAZ.Add(cihaz);
            }
            else// guncelleme işlemi 
            {
               var  guncelle_cihaz= db.CIHAZ.Find(cihaz.CIHAZ_ID);
                guncelle_cihaz.CIHAZ_AD = cihaz.CIHAZ_AD;
                guncelle_cihaz.BIRIM_FIYAT = cihaz.BIRIM_FIYAT;
                guncelle_cihaz.ISLEM_BILGISI = cihaz.ISLEM_BILGISI;

                db.CIHAZ.Attach(guncelle_cihaz);
                db.Entry(guncelle_cihaz).State = System.Data.Entity.EntityState.Modified;
                
            }
            db.SaveChanges();
            return View("Index",db.CIHAZ.ToList());          

        }
        public ActionResult Ekle(CIHAZ cihaz)
        {           
            return View("Guncelle");

        }
        //[HttpGet]
        //public ActionResult DosyaYukle()
        //{           
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult DosyaYukle(HttpPostedFileBase yuklenecekDosya)
        //{
        //    //DateTime dt = DateTime.Today;
        //    //Dosya dosya = new Dosya();
        //    //string tarih = dt.Day + "-" + dt.Month + "-" + dt.Year;

        //    //if (yuklenecekDosya != null)
        //    //{                
        //    //    string dosyaYolu = Path.GetFileName(yuklenecekDosya.FileName);
        //    //    dosya.Dosya_Ad = dosyaYolu;
        //    //    dosya.Dosya_Tarih = tarih;
        //    //    var yuklemeYeri = Path.Combine(Server.MapPath("~/Folders"), dosyaYolu);
        //    //    yuklenecekDosya.SaveAs(yuklemeYeri);
        //    //    db.Dosya.Add(dosya);
        //    //}
        //    //db.SaveChanges();
        //    //return RedirectToAction("Index");

        //    string FileExt = Path.GetExtension(yuklenecekDosya.FileName).ToUpper();


        //    DateTime dt = DateTime.Today;
        //    Dosya dosya = new Dosya();
        //    string tarih = dt.Day + "-" + dt.Month + "-" + dt.Year;
        //    if (FileExt == ".PDF")
        //    {
        //        Stream str = yuklenecekDosya.InputStream;
        //        BinaryReader Br = new BinaryReader(str);
        //        Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

        //        dosya.Dosya_Ad = yuklenecekDosya.FileName;
        //        dosya.Dosya_Tarih = tarih;
        //        dosya.Dosya_Icerik = FileDet;
        //        db.Dosya.Add(dosya);db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {

        //        return View();

        //    }
        }
      


   
}