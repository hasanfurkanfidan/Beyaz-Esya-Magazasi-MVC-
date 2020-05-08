using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
     MVCBDSTOKEntities db = new MVCBDSTOKEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORI.ToList();
            var degerler = db.TBLKATEGORI.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            db.TBLKATEGORI.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int Id)
        {
            var kategori = db.TBLKATEGORI.Find(Id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(TBLKATEGORI p1)
        {
            var ktg = db.TBLKATEGORI.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}