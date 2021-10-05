using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GorkemAydogduProje.Models.Database;
namespace GorkemAydogduProje.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
        GA_StajProjeEntities db = new GA_StajProjeEntities();
        public ActionResult Index()
        {    
            var projeler = db.tbl_Proje.ToList();
            return View(projeler);
        }
        [HttpGet]
        public ActionResult YeniProje()
        {
            return View(); /* Sayfada işlem yapılmazsa sayfayı geri döndürür*/
        }
        [HttpPost]
        public ActionResult YeniProje(tbl_Proje ekle) {
            db.tbl_Proje.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id) 
        {
            var proje = db.tbl_Proje.Find(id); /* proje tablosunda id gelen değeri bul*/
            db.tbl_Proje.Remove(proje); /*projeden glen değeri sil*/
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProjeGetir(int id)
        {
            var proje = db.tbl_Proje.Find(id);
            return View("ProjeGetir", proje);
        }
        public ActionResult Guncelle(tbl_Proje guncelle)
        {
            var proje = db.tbl_Proje.Find(guncelle.Id);
            proje.Durumu = guncelle.Durumu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}