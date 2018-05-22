﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RunnersLog.Models;

namespace RunnersLog.Controllers
{
    public class RunsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Runs
        public ActionResult Index(int? searchString)
        {

            var runs = from m in db.Runs
                select m;

            if (searchString != null)
            {
                runs = runs.Where(s => s.Distance == searchString);
            }

            return View(runs);
           
        }

        // GET: Runs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            return View(run);
        }

        // GET: Runs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Runs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Distance,Time,HeartRate,Calories,Date")] Run run)
        {
            if (ModelState.IsValid)
            {
                db.Runs.Add(run);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(run);
        }

        // GET: Runs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            return View(run);
        }

        // POST: Runs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Distance,Time,HeartRate,Calories,Date")] Run run)
        {
            if (ModelState.IsValid)
            {
                db.Entry(run).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(run);
        }

        // GET: Runs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            return View(run);
        }

        // POST: Runs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Run run = db.Runs.Find(id);
            db.Runs.Remove(run);
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
