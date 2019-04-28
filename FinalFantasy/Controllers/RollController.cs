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
using PagedList;
using System.Data.Entity.Infrastructure;

namespace FinalFantasy.Controllers
{
    public class RollController : Controller
    {
        private FinalFantasyContext db = new FinalFantasyContext();

        // GET: Roll
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var rolls = from s in db.Rolls
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                rolls = rolls.Where(s => s.RollName.Contains(searchString)
                                            || s.RollAbr.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    rolls = rolls.OrderByDescending(s => s.RollName);
                    break;
                case "Date":
                    rolls = rolls.OrderBy(s => s.RaidDate);
                    break;
                case "date_desc":
                    rolls = rolls.OrderByDescending(s => s.RaidDate);
                    break;
                default: //Name ascending
                    rolls = rolls.OrderBy(s => s.RollName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(rolls.ToPagedList(pageNumber, pageSize));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDisplay([Bind(Include = "ID,RollName,RollAbr,RaidDate")] Roll roll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View(roll);
        }

        // GET: Roll/Edit/5
        public ActionResult EditDisplay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Rolls.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        public ActionResult Display()
        {
            return View(db.Rolls.ToList());
        }


        // GET: Roll/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Rolls.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        // GET: Roll/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roll/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RollName,RollAbr,RaidDate")] Roll roll)
        {
            try
            {
            if (ModelState.IsValid)
            {
                db.Rolls.Add(roll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(roll);
        }

        // GET: Roll/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Rolls.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        // POST: Roll/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RollName,RollAbr,RaidDate")] Roll roll)
        {
            try
            {
            if (ModelState.IsValid)
            {
                db.Entry(roll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(roll);
        }

        // GET: Roll/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Roll roll = db.Rolls.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        // POST: Roll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
            Roll roll = db.Rolls.Find(id);
            db.Rolls.Remove(roll);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

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
