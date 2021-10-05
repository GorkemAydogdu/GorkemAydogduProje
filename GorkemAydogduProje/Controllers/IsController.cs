using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GorkemAydogduProje.Models.Database;
namespace GorkemAydogduProje.Controllers
{
    public class IsController : Controller
    {
        // GET: Is
        GA_StajProjeEntities db = new GA_StajProjeEntities();
        public ActionResult Index()
        {
            var isler = db.tbl_Is.ToList();
            return View(isler);
        }
        [HttpGet]
        public ActionResult IsEkle()
        {
            List<SelectListItem> degerler = (from i in db.tbl_Proje.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ProjeAdi,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult IsEkle(tbl_Is ekle)
        {
            var isler = db.tbl_Proje.Where(m => m.Id == ekle.tbl_Proje.Id).FirstOrDefault();
            ekle.tbl_Proje = isler;
            db.tbl_Is.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id) 
        {
            var isler = db.tbl_Is.Find(id);
            db.tbl_Is.Remove(isler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IsleriGetir(int id)
        {
            var isler = db.tbl_Is.Find(id);
            return View("IsleriGetir", isler);
        }
        public ActionResult Guncelle(tbl_Is guncelle)
        {
            var isler = db.tbl_Is.Find(guncelle.Id);
            isler.Durumu = guncelle.Durumu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}