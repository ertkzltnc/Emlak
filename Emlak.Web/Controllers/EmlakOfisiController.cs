
using Emlak.BLL.Repositories;
using Emlak.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace PiDataEmlak.Web.Controllers
{
    public class EmlakOfisiController : Controller
    {

        EmlakOfisiRepository emlakOfisiRepository = new EmlakOfisiRepository();
        IlRepository ilRepository = new IlRepository();
        IlceRepository ilceRepository = new IlceRepository();
        MahalleRepository mahalleRepository = new MahalleRepository();

        // GET: EmlakOfisi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YetkiliGiris()
        {
            return View();
        }
        //unique olarak tanımladığımız yetkili adının emlak ofisi tablosunda tespit ediyoruz.
        // Tablo icerisinde yetkili kişi adı ile sifre eşlesmesi kontrol ediliyor eşleşme sağladığında giris yapıyoruz
        [HttpPost]
        public ActionResult YetkiliGiris(EmlakOfisi emlakOfisi)
        {
            try
            {
                if (emlakOfisiRepository.Login(emlakOfisi.Yetkili, emlakOfisi.Sifre))
                {
                    ViewBag.Message = "**Kullanıcı Bilgileri Hatalı**";
                    return View();

                }
                else
                {
                    Session["Yetkili"] = emlakOfisi.Yetkili;
                    return RedirectToAction("Index", "Musteri");
                }

            }
            catch (Exception)
            {

                ViewBag.Message = "**KUllanıcı Bilgileri Hatalı**";
                return View();
            }


        }
        public ActionResult EmlakOfisiEkle()
        {
            ViewBag.ilList = ilRepository.GetAll();


            return View();
        }
        public ActionResult Profil(string yetkili)
        {
            EmlakOfisi emlakOfisi = emlakOfisiRepository.YetkiliGetir(yetkili);

            return View(emlakOfisi);
        }

        [HttpPost]
        public ActionResult IlceGetir(int ilID)
        {

            var ilceList = ilceRepository.IlceGetir(ilID);

            //return Json(ilceList, JsonRequestBehavior.AllowGet);
            return Json(new SelectList(ilceList, "ID", "Ad"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MahalleGetir(int ilceID)
        {
            var mahalleList = mahalleRepository.MahalleGetir(ilceID);
            //return Json(mahalleList, JsonRequestBehavior.AllowGet);
            return Json(new SelectList(mahalleList, "ID", "Ad"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EmlakOfisiEkle(EmlakOfisi em)
        {
            /*
             * EmlakOfis eklemede tablo  alanları için gerekli kısıtlar html sayfasında belirtilmiştir. 
             * Burada sadece null durumları kontrol ediliyor
             
             */

            string createMessage = "";
            try
            {
                if (em.Ad == null || em.AdresAyrinti == null || em.Yetkili == null || em.Sifre == null || em.Eposta == null)
                {

                    ViewBag.Message = "Tüm AlanlarıDoldurunuz";
                    return View();
                }
                else
                {
                    emlakOfisiRepository.Insert(em);

                    ViewBag.Message = "Kayit Basarili";
                    return RedirectToAction("YetkiliGiris");
                }





            }
            catch (Exception)
            {
                createMessage = "Sistem Hatası";
                ViewBag.CreateMessage = createMessage;
                return RedirectToAction("EmlakOfisiEkle");

            }
        }

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("YetkiliGiris", "EmlakOfisi");
        }
    }
}