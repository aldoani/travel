using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using travel.Models;

namespace travel.Controllers
{
    public class reservesController : Controller
    {
        private DB_travelsEntities3 db = new DB_travelsEntities3();

        // GET: reserves
        public ActionResult Index()
        {
            var reserves = db.reserves.Include(r => r.travels_tb);
            return View(reserves.ToList());
        }

        // GET: reserves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserve reserve = db.reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        // GET: reserves/Create
        public ActionResult Create()
        {
            ViewBag.travel_id = new SelectList(db.travels_tb, "travel_id", "travel_name");
            return View();
        }

        // POST: reserves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resarve_id,user_name,name,travel_id")] reserve reserve)
        {
            if (ModelState.IsValid)
            {
                db.reserves.Add(reserve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.travel_id = new SelectList(db.travels_tb, "travel_id", "travel_name", reserve.travel_id);
            return View(reserve);
        }

        // GET: reserves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserve reserve = db.reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            ViewBag.travel_id = new SelectList(db.travels_tb, "travel_id", "travel_name", reserve.travel_id);
            return View(reserve);
        }

        // POST: reserves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resarve_id,user_name,name,travel_id")] reserve reserve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.travel_id = new SelectList(db.travels_tb, "travel_id", "travel_name", reserve.travel_id);
            return View(reserve);
        }

        // GET: reserves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserve reserve = db.reserves.Find(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        // POST: reserves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reserve reserve = db.reserves.Find(id);
            db.reserves.Remove(reserve);
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
