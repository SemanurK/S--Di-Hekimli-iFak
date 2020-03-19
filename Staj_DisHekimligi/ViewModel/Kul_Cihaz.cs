using Staj_DisHekimligi.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj_DisHekimligi.ViewModel
{
    public class Kul_Cihaz
    {
        public IEnumerable<CIHAZ> cihazs { get; set; }
        public string kul_ad { get; set; }
        public string sifre { get; set; }
        public string ad_soyad { get; set; }

    }
}