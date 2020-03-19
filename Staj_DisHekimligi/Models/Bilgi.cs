using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_DisHekimligi
{
    public class Bilgi
    {
      
       
        private string proje_ismi, proje_yöneticisi, diger_arastiricilar;
   
        private string eposta, tel, fax;
        private string unvan;
        private string calistigi_kurum_tip;
        private string calistigi_kurum_ad;
        private string calistigi_birim_ad;
        private string anabilim_dali;
  
        [Required (ErrorMessage ="Bu alan boş geçilemez...")]
        public string Proje_yöneticisi { get => proje_yöneticisi; set => proje_yöneticisi = value; }
       [Required(ErrorMessage = "Bu alan boş geçilemez...")]
        public string Proje_ismi { get => proje_ismi; set => proje_ismi = value; }
      
      //  public string[] Unvan { get => unvan; set => unvan = value; }
       [Required (ErrorMessage = "Bu alan boş geçilemez...")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@(?:(?:[a-zA-Z0-9-]+\.)?[a-zA-Z]+\.)?(selcuk.edu|ogrenci.selcuk.edu)\.tr",ErrorMessage ="İstenilen formatta email adresini giriniz.")]
        public string Eposta { get => eposta; set => eposta = value; }
       [Required(ErrorMessage = "Bu alan boş geçilemez...")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçersiz telefon numarası")]
        public string Tel { get => tel; set => tel = value; }
      [Required(ErrorMessage = "Bu alan boş geçilemez...")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçersiz fax numarası")]
        public string Fax { get => fax; set => fax = value; }
      [Required(ErrorMessage = "Bu alan boş geçilemez...")]
        public string Unvan { get => unvan; set => unvan = value; }
       [Required(ErrorMessage = "Bu alan boş geçilemez...")]
        public string Diger_arastiricilar { get => diger_arastiricilar; set => diger_arastiricilar = value; }
       [Required(ErrorMessage = "Bu alan boş geçilemez...")]
       public int Calistigi_kurum_tip { get; set; }      
       [Required(ErrorMessage = "Bu alan boş geçilemez...")]
        public int Calistigi_kurum_ad { get; set ; }
     [Required(ErrorMessage = "Bu alan boş geçilemez...")]
        public string Calistigi_birim_ad { get => calistigi_birim_ad; set => calistigi_birim_ad = value; }
       [Required(ErrorMessage = "Bu alan boş geçilemez...")]
        public string Anabilim_dali { get => anabilim_dali; set => anabilim_dali = value; }
      

    
      

    }

}