using Staj_DisHekimligi.Entitiy;
using Staj_DisHekimligi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj_DisHekimligi.ViewModel
{
    public class BilgiViewModel
    {
        public IEnumerable<Kurum_Ad> _Ads { get; set; }
        public IEnumerable<Kurum_Tip> Tips { get; set; }
        public IEnumerable<CIHAZ> cihazs { get; set; }
        public Bilgi bilgi { get; set; }
    }
}