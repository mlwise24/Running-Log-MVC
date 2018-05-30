using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using RunnersLog.Models;





namespace RunnersLog.Controllers
{
    public class ReportingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        public int days3 { get; set; }


        // GET: Reporting/Details/5
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            Reporting reporting = new Reporting();
            

            var runs = from m in db.Runs
                select m;

            if (startDate != null && endDate != null)
            {
                runs = runs.Where(s => s.Date >= startDate && s.Date <= endDate);

            }

           // var totalDistance = runs.Select(s => s.Distance).ToList();
           // var totalCalories = runs.Select(s => s.Calories).ToList();
           //
            //reporting.TotalCalories = totalCalories.Sum();
            //reporting.TotalDistance = totalDistance.Sum();
           

           // ViewBag.td = reporting.TotalDistance;
           // ViewBag.tc = reporting.TotalCalories;
         
            

            return View(runs);

        }
      
        // GET: Reporting/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Reporting/Create
        [HttpPost]
        public ActionResult Create(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                Reporting reporting = new Reporting();
                reporting.TotalDistance = 0;


                var runs = from m in db.Runs
                           select m;

                if (startDate != null && endDate != null)
                {
                    runs = runs.Where(s => s.Date >= startDate && s.Date <= endDate);



                    var totalDistance = runs.Select(s => s.Distance).ToList();
                    reporting.TotalDistance = totalDistance.Sum();
                    ViewBag.td = reporting.TotalDistance;

                    var totalCalories = runs.Select(s => s.Calories).ToList();
                    reporting.TotalCalories = totalCalories.Sum();
                    ViewBag.tc = reporting.TotalCalories;
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Reporting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reporting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reporting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reporting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
