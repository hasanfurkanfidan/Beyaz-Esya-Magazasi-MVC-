using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MVCBDSTOKEntities db = new MVCBDSTOKEntities();
        public ActionResult Index(string p)
        {
           //var degerler=  db.TBLMUSTERILER.ToList();
            //return View(degerler);
            var degerler = from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult MusteriSil(int id)
        {
           var musteri =  db.TBLMUSTERILER.Find(id);
           db.TBLMUSTERILER.Remove(musteri);
           db.SaveChanges();
           return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult GUNCELLE(TBLMUSTERILER p2)
        {
           var mus=  db.TBLMUSTERILER.Find(p2.MUSTERIID);
           mus.MUSTERIAD = p2.MUSTERIAD;
           mus.MUSTERISOYAD = p2.MUSTERISOYAD;
           db.SaveChanges();
           return RedirectToAction("Index");
        }
    }
}