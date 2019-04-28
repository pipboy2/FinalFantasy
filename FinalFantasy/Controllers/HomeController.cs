using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalFantasy.DAL;
using FinalFantasy.ViewModels;

namespace FinalFantasy.Controllers
{
    public class HomeController : Controller
    {
        private FinalFantasyContext db = new FinalFantasyContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RaidStats()
        {
            IQueryable<RaidtDateGroup> data = from roll in db.Rolls
                                                   group roll by roll.RaidDate into dateGroup
                                                   select new RaidtDateGroup()
                                                   {
                                                       RaidDate = dateGroup.Key,
                                                       RollCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}