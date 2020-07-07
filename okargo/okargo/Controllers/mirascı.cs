using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace okargo.Controllers
{
    public class mirascı:HomeController
    {
        public static string ad { get; set; }
        public void mirascik(string isim_soyisim)
        {
            ad = isim_soyisim;       
        }
        public string dondur()
        {
            return ad;
        }
    }
}