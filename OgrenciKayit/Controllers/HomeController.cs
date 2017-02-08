using OgrenciKayit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciKayit.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OgrenciKaydet(string OgrAd, string OgrSoyad, string DersAdi, int DersNotu)
        {
            if (HttpRuntime.Cache["Ogrenciler"]==null)
            {
                List<Ogrenci> OgrenciListesi = new List<Ogrenci>();
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Ad = OgrAd;
                ogrenci.Soyad = OgrSoyad;
                ogrenci.DersAd = DersAdi;
                ogrenci.DersNot = DersNotu;

                OgrenciListesi.Add(ogrenci);
                HttpRuntime.Cache["Ogrenciler"] = OgrenciListesi; //ramde bir alan acip tutmak istedigimizi tutar.
            }
            else
            {
                List<Ogrenci> OgrenciListesi = (List<Ogrenci>)HttpRuntime.Cache["Ogrenciler"];
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Ad = OgrAd;
                ogrenci.Soyad = OgrSoyad;
                ogrenci.DersAd = DersAdi;
                ogrenci.DersNot = DersNotu;

                OgrenciListesi.Add(ogrenci);
                HttpRuntime.Cache["Ogrenciler"] = OgrenciListesi;

            }
            
            
           

            return RedirectToAction("OgrenciListesi");  //bu actiondan baska bir actiona yönlenme demek.

        }

        public ActionResult OgrenciListesi()
        {
            var model = (List<Ogrenci>)HttpRuntime.Cache["Ogrenciler"];
            return View(model);
        }
    }
}