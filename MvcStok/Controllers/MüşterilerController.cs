using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class MüşterilerController : Controller
    {
        DbMvcStokEntities db=new DbMvcStokEntities();

        public ActionResult Index()
        {
            var values = db.TblMusteriler.ToList();
            return View(values);
        }
        public ActionResult SIL(int id)
        {
            var values = db.TblMusteriler.Find(id);
            db.TblMusteriler.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteriler p)
        {
            db.TblMusteriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult GUNCELLE(int id)
        {
           var values= db.TblMusteriler.Find(id);
           return View(values);
        }
        [HttpPost]
        public ActionResult GUNCELLE(TblMusteriler p)
        {
            var values = db.TblMusteriler.Find(p.MusteriID);
            values.MusteriAd=p.MusteriAd;
            values.MusteriSoyad = p.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}