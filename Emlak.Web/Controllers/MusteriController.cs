
using Emlak.BLL.Repositories;
using Emlak.DAL.Context;
using Emlak.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDataEmlak.Web.Controllers
{
    public class MusteriController : Controller
    {
      
        MusteriRepository musteriRepository = new MusteriRepository();
        IlRepository ilRepository = new IlRepository();
        IlceRepository ilceRepository = new IlceRepository();
        MahalleRepository mahalleRepository = new MahalleRepository();
        public MusteriController()
        {
            ViewBag.Musteri = "selected";

        }
        // GET: Musteri
        public ActionResult Index()
        {
            List<Musteri> musteriList = musteriRepository.GetAll();

            return View(musteriList);
        }
        public ActionResult MusteriEkle()
        {
            ViewBag.ilList = ilRepository.GetAll();


            return View();
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
        public ActionResult MusteriEkle(Musteri musteri)
        {
            musteriRepository.Insert(musteri);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult MusteriSil(int id)
        {
            try
            {
                Musteri musteri = musteriRepository.GetByID(id);
                musteriRepository.Delete(musteri);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View();

            }

        }
        public ActionResult MusteriGuncelle(int id)
        {
            ViewBag.ilList = ilRepository.GetAll();
            ViewBag.ilceList = ilceRepository.GetAll();
            ViewBag.mahalleList = mahalleRepository.GetAll();
            Musteri musteri = musteriRepository.GetByID(id);
            return View(musteri);
        }
        [HttpPost]
        public ActionResult MusteriGuncelle(Musteri musteri)
        {


            if (ModelState.IsValid)
            {
                Musteri m = musteriRepository.GetByID(musteri.ID);

                m.ID = musteri.ID;
                m.IlceID = musteri.IlceID;
                m.IlID = musteri.IlID;
                m.MahalleID = musteri.MahalleID;
                m.Soyad = musteri.Soyad;
                m.AdresAyrinti = musteri.AdresAyrinti;
                m.CepTelefonu = musteri.CepTelefonu;
                m.Eposta = musteri.Eposta;
                m.EvTelefonu = musteri.EvTelefonu;
                m.Ad = musteri.Ad;

                musteriRepository.Update(m);

                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

        }

    }
}