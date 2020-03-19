using Staj_DisHekimligi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_DisHekimligi.DataManager
{
    public class DataManager
    {
       
        public static List<Kurum_Tip> GetKurum_Tips()
        {
           List<Kurum_Tip> kurum_Tips;
         
             kurum_Tips = new List<Kurum_Tip>()
                {
                    new Kurum_Tip{tip_id=1,tip_adi="Üniversite"},
                    new Kurum_Tip{tip_id=2,tip_adi="Özel Sağlık Kuruluşları"},
                    new Kurum_Tip{tip_id=3,tip_adi="Diğer"},
                };
            return kurum_Tips;
        }
        public static List<Kurum_Ad> GetKurum_Ads(int id)
        {
           List<string> universiteler = null;
            ServiceReferenceYoksis.yoksisOgrSoapClient servisYoksis = new ServiceReferenceYoksis.yoksisOgrSoapClient();
            ServiceReferenceYoksis.Universitev4[] yoksisresult = new ServiceReferenceYoksis.Universitev4[0];
            yoksisresult = servisYoksis.UniversiteleriGetir();
            List<Kurum_Ad> k_ad1 = new List<Kurum_Ad>();
            int k_id = 1;
            foreach (var item in yoksisresult)
            {
                k_ad1.Add(new Kurum_Ad { k_id = k_id, tip_id = 1, kurum_adi = item.BIRIM_ADI });
                k_id++;
            }
            Kurum_Ad k_ad4 = new Kurum_Ad { k_id = k_id, tip_id = 2, kurum_adi = "Özel Sağlık Kuruluşları" }; k_id++;
            List<Kurum_Ad> tum_kurum_ads = null;

            Kurum_Ad k_ad2 = new Kurum_Ad { k_id = k_id, tip_id = 2, kurum_adi = "Diğer" }; k_id++;
            Kurum_Ad k_ad3 = new Kurum_Ad { k_id = k_id, tip_id = 3, kurum_adi = "Diğer" };
            tum_kurum_ads = new List<Kurum_Ad> { k_ad2, k_ad3, k_ad4 };
            tum_kurum_ads.AddRange(k_ad1);
            List<Kurum_Ad> kurum_ads = tum_kurum_ads.Where(k => k.tip_id == id).ToList();


            return kurum_ads;
            //gelen json paketlerine göre izin ver JsonRequestBehavior 
        }

       
    }
}