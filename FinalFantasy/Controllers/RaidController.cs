using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalFantasy.DAL;
using FinalFantasy.Models;

namespace FinalFantasy.Controllers
{
    public class RaidController : Controller
    {

        private FinalFantasyContext db = new FinalFantasyContext();

        // GET: Raid
        public ActionResult Index()
        {
            var raids = db.Raids.Include(r => r.Job).Include(r => r.Roll);
            return View(raids.ToList());
        }

        // GET: Raid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = db.Raids.Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View(raid);
        }

        // GET: Raid/Create
        public ActionResult Create()
        {
            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "Title");
            ViewBag.RollID = new SelectList(db.Rolls, "ID", "RollName");
            return View();
        }

        // POST: Raid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaidID,JobID,RollID,Day")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                db.Raids.Add(raid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "Title", raid.JobID);
            ViewBag.RollID = new SelectList(db.Rolls, "ID", "RollName", raid.RollID);
            return View(raid);
        }

        // GET: Raid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = db.Raids.Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "Title", raid.JobID);
            ViewBag.RollID = new SelectList(db.Rolls, "ID", "RollName", raid.RollID);
            return View(raid);
        }

        // POST: Raid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaidID,JobID,RollID,Day")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "Title", raid.JobID);
            ViewBag.RollID = new SelectList(db.Rolls, "ID", "RollName", raid.RollID);
            return View(raid);
        }

        // GET: Raid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = db.Raids.Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View(raid);
        }

        // POST: Raid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raid raid = db.Raids.Find(id);
            db.Raids.Remove(raid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
