using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatısController : Controller
    {
         DbMvcStokEntities db=new DbMvcStokEntities();  
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniSatis(TblSatışlar p)
        {
            db.TblSatışlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

           

        }
    }
}