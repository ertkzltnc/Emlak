
using Emlak.BLL.Repositories;
using Emlak.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDataEmlak.Web.Controllers
{
    public class IlanController : Controller
    {
        KonutRepository konutRepository = new KonutRepository();
        IlanTurRepository ilanTurRepository = new IlanTurRepository();
        IlRepository ilRepository = new IlRepository();
        IlceRepository ilceRepository = new IlceRepository();
        MahalleRepository mahalleRepository = new MahalleRepository();
        IsitmaTurRepository isitmaTurRepository = new IsitmaTurRepository();
        FotografRepository fotografRepository = new FotografRepository();
        MusteriRepository musteriRepository = new MusteriRepository();

        //nav-bar üzerinde secili index belirli olsun diye selected yapıyoruz.
        public IlanController()
        {
            ViewBag.Ilan = "selected";

        }
        /*
         * Bir konut için birden fazla resim eklenebilir. Resimlerimiz Byte[] olarak kaydettiğimiz için Resimler içerisine 
         * Base64 ekleyerek resmi gösteriyoruz.
         * Konutlar üzerinden erişim sağlamaya çalıştığımızda byte[] olarak tuttuğumuz resimlerin Base64 e erişim sağlamak için resimler üzerinden konutlara
         * erişiyoruz. 
         * Model katmanında entities altında KonutResimViewModel classı bize bir konut için n tane resim ekleme ve bunlara erişim sağlıyor.
             */

        public ActionResult Index()
        {

            List<Fotograf> resimList = fotografRepository.GetAll();

            ViewBag.ilanTurList = ilanTurRepository.GetAll();
            ViewBag.ilList = ilRepository.GetAll();


            return View(resimList);
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


        public ActionResult IlanEkle(int id)
        {


            ViewBag.ilList = ilRepository.GetAll();

            ViewBag.ilanTurList = ilanTurRepository.GetAll();

            ViewBag.isitmaTurList = isitmaTurRepository.GetAll();
            Musteri musteri = musteriRepository.GetByID(id);

            return View(musteri);
        }

        [HttpPost]
        public ActionResult IlanEkle(Konut konut, HttpPostedFileBase Resim, HttpPostedFileBase Resim2)
        {


            konutRepository.Insert(konut);
            if (Resim != null)
            {
                Fotograf foto = new Fotograf()
                {
                    Resim = ConvertToBytes(Resim),
                    KonutID = konut.ID

                };
                fotografRepository.Insert(foto);


                // Birden fazla resim eklenmek istendiğinde

                //Fotograf foto2 = new Fotograf()
                //{
                //    Resim = ConvertToBytes(Resim2),
                //    KonutID = konut.ID

                //};
                //fotografRepository.Insert(foto2);

            }



            return RedirectToAction("Index", "Musteri");
        }
        public ActionResult KonutDetay(int id)
        {
            // id=KonutID 
            Fotograf resimList = fotografRepository.GetByID(id);
            return View(resimList);
        }


        //byte[] olarak kaydettiğimiz resimlerin bağlantısı byte[] tipine cevirme için kullanıyoruz
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes(image.ContentLength);
            byte[] bytes = new byte[imageBytes.Length + 78];
            Array.Copy(imageBytes, 0, bytes, 78, imageBytes.Length);
            return bytes;
        }
    }
}