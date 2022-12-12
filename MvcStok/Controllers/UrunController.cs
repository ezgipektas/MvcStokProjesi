using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        DbMvcStokEntities db=new DbMvcStokEntities();
        public ActionResult Index()
        {
            var values = db.TblUrunler.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> values = (from i in db.TblKategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KategoriAd,
                                               Value = i.KategoriID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TblUrunler p)
        {
            var values = db.TblKategoriler.Where(x => x.KategoriID == p.TblKategoriler.KategoriID).FirstOrDefault();
            p.TblKategoriler = values;
            db.TblUrunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var values = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GUNCELLE(int id)
        {
            var value=db.TblUrunler.Find(id);
            List<SelectListItem> values = (from i in db.TblKategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KategoriAd,
                                               Value = i.KategoriID.ToString()
                                           }).ToList();
            ViewBag.v2 = values;
            return View(value);
        }
        [HttpPost]
        public ActionResult GUNCELLE(TblUrunler p)
        {
            var values = db.TblUrunler.Find(p.UrunID);
            values.UrunAd = p.UrunAd;
            values.Marka = p.Marka;
            //values.UrunKategori = p.UrunKategori;
            var values1 = db.TblKategoriler.Where(x => x.KategoriID == p.TblKategoriler.KategoriID).FirstOrDefault();
            values.UrunKategori = values1.KategoriID;
            values.Fiyat = p.Fiyat;
            values.Stok = p.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}