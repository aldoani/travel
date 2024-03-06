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
    public class travels_tb1Controller : Controller
    {
        private DB_travelsEntities3 db = new DB_travelsEntities3();

        // GET: travels_tb1
        public ActionResult Index()
        {
            var travels_tb = db.travels_tb.Include(t => t.bus).Include(t => t.line);
            return View(travels_tb.ToList());
        }

        // GET: travels_tb1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            travels_tb travels_tb = db.travels_tb.Find(id);
            if (travels_tb == null)
            {
                return HttpNotFound();
            }
            return View(travels_tb);
        }

        // GET: travels_tb1/Create
        public ActionResult Create()
        {
            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_name");
            ViewBag.line_id = new SelectList(db.lines, "line_id", "line_name");
            return View();
        }

        // POST: travels_tb1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "travel_id,travel_name,travel_from,travel_to,travel_time_date,travel_price,bus_id,line_id")] travels_tb travels_tb)
        {
            if (ModelState.IsValid)
            {
                db.travels_tb.Add(travels_tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_name", travels_tb.bus_id);
            ViewBag.line_id = new SelectList(db.lines, "line_id", "line_name", travels_tb.line_id);
            return View(travels_tb);
        }

        // GET: travels_tb1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            travels_tb travels_tb = db.travels_tb.Find(id);
            if (travels_tb == null)
            {
                return HttpNotFound();
            }
            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_name", travels_tb.bus_id);
            ViewBag.line_id = new SelectList(db.lines, "line_id", "line_name", travels_tb.line_id);
            return View(travels_tb);
        }

        // POST: travels_tb1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "travel_id,travel_name,travel_from,travel_to,travel_time_date,travel_price,bus_id,line_id")] travels_tb travels_tb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travels_tb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bus_id = new SelectList(db.buses, "bus_id", "bus_name", travels_tb.bus_id);
            ViewBag.line_id = new SelectList(db.lines, "line_id", "line_name", travels_tb.line_id);
            return View(travels_tb);
        }

        // GET: travels_tb1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            travels_tb travels_tb = db.travels_tb.Find(id);
            if (travels_tb == null)
            {
                return HttpNotFound();
            }
            return View(travels_tb);
        }

        // POST: travels_tb1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            travels_tb travels_tb = db.travels_tb.Find(id);
            db.travels_tb.Remove(travels_tb);
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
