using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
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
        DbMvcStokEntities db=new DbMvcStokEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var values = db.TblKategoriler.ToList();
            var values = db.TblKategoriler.ToList().ToPagedList(sayfa, 3);
            return View(values);
        }
        [HttpPost]
        public ActionResult YeniKategori(TblKategoriler p)
        {
            db.TblKategoriler.Add(p);
            db.SaveChanges();
           return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        public ActionResult SIL(int id)
        {
            var values = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GUNCELLE(int id)
        {
            var values = db.TblKategoriler.Find(id);
            return View(values);


        }
        [HttpPost]
        public ActionResult GUNCELLE(TblKategoriler p)
        {
            var values = db.TblKategoriler.Find(p.KategoriID);
            values.KategoriAd = p.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}