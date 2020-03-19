using Staj_DisHekimligi.Entitiy;
using Staj_DisHekimligi.Models;
using Staj_DisHekimligi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_DisHekimligi.Controllers
{
    public class HomeController : Controller
    {
        Bilgi bilgi = new Bilgi();
        Entities db = new Entities();
        static List<CIHAZ> cihazlar = new List<CIHAZ>();

        public ActionResult Index()
        {
            cihazlar.Clear();
            var bos = Enumerable.Empty<Kurum_Ad>();
            var model = new BilgiViewModel()
            {
                Tips = DataManager.DataManager.GetKurum_Tips(),
                _Ads = bos,
                cihazs=db.CIHAZ.ToList()

            };         
            return View(model);           
             
        }
      

        [HttpPost]
        public ActionResult Kaydet(BilgiViewModel b)
        {
            var model = new BilgiViewModel()
            {
                Tips = DataManager.DataManager.GetKurum_Tips(),
                _Ads = DataManager.DataManager.GetKurum_Ads(b.bilgi.Calistigi_kurum_tip),             
                cihazs=cihazlar,
                 bilgi = b.bilgi

            };
            var model2 = new BilgiViewModel()
            {
                Tips = DataManager.DataManager.GetKurum_Tips(),
                _Ads = DataManager.DataManager.GetKurum_Ads(b.bilgi.Calistigi_kurum_tip),             
                cihazs = db.CIHAZ.ToList(),
                bilgi = b.bilgi

            };
            if (!ModelState.IsValid)
            {
                cihazlar.Clear();
                return View("Index", model2);
                //  return View("Talep_Form", model);
            }
            else
            {

                return View("Talep_Form", model);
            }
        }
       
        public void Liste(int id,int deger)
        {
            CIHAZ chz = new CIHAZ();
            var model = db.CIHAZ.Where(m => m.CIHAZ_ID == id).FirstOrDefault();          
            chz = cihazlar.Find(x => (x.CIHAZ_ID == model.CIHAZ_ID));
            if (deger != 0)
            {
                if (chz != null)
                {
                    if (chz.SUTUN_ICERIK != deger)
                    {
                        cihazlar.Remove(chz);
                        model.SUTUN_ICERIK = deger;

                        model.TOPLAM_FIYAT = (int)model.BIRIM_FIYAT * deger;
                        //cihazlar.Remove(chz);
                        cihazlar.Add(model);

                    }
                    var cihazlist = cihazlar;
                }
                else
                {
                    model.SUTUN_ICERIK = deger;
                    model.TOPLAM_FIYAT = (int)model.BIRIM_FIYAT * deger;
                    cihazlar.Add(model);
                }
            }
            else if(deger==0 && chz!=null)
            {
                cihazlar.Remove(chz);
            }
        }
      
        [HttpPost]
         public JsonResult GetKurumAd(int id)
         {
            var model = DataManager.DataManager.GetKurum_Ads(id);
            return Json(model, JsonRequestBehavior.AllowGet);
             //gelen json paketlerine göre izin ver JsonRequestBehavior 
         }
       
    }
}