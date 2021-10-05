using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GorkemAydogduProje.Models.Database;
namespace GorkemAydogduProje.Controllers
{
    public class IsAciklamalariController : Controller
    {
        // GET: IsAciklamalari
        GA_StajProjeEntities db = new GA_StajProjeEntities();
        public ActionResult Index()
        {
            var isAciklamalari = db.tbl_IsAciklama.ToList();
            return View(isAciklamalari);
        }
        [HttpGet]
        public ActionResult AciklamaEkle() 
        {
            List<SelectListItem> degerler1 = (from i in db.tbl_Is.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.IsAdi,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr1 = degerler1;
            List<SelectListItem> degerler2 = (from i in db.tbl_Calisan.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CalisanAdi,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr2 = degerler2;
            return View();
        }
        [HttpPost]
        public ActionResult AciklamaEkle(tbl_IsAciklama ekle)
        {
            var aciklama1 = db.tbl_Is.Where(m => m.Id == ekle.tbl_Is.Id).FirstOrDefault();
            ekle.tbl_Is = aciklama1;

            var aciklama2 = db.tbl_Calisan.Where(m => m.Id == ekle.tbl_Calisan.Id).FirstOrDefault();
            ekle.tbl_Calisan = aciklama2;
            db.tbl_IsAciklama.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var aciklama = db.tbl_IsAciklama.Find(id);
            db.tbl_IsAciklama.Remove(aciklama);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AciklamalariGetir(int id)
        {
            var aciklama = db.tbl_IsAciklama.Find(id);
            return View("AciklamalariGetir", aciklama);
        }
        public ActionResult Guncelle(tbl_IsAciklama guncelle)
        {
            var aciklama = db.tbl_IsAciklama.Find(guncelle.Id);
            aciklama.Durum = guncelle.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}