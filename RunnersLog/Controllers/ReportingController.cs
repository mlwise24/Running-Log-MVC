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
using Microsoft.AspNet.Identity;





namespace RunnersLog.Controllers
{
    public class ReportingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        int days = 0;
        
        // GET: Reporting/Details/5
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            Reporting reporting = new Reporting();

            var loggedin = User.Identity.GetUserId();
            
            var runs = from m in db.Runs
                select m;
            runs = runs.Where(s => s.RunId.ToString() == loggedin);

            if (startDate != null && endDate != null)
            {
                runs = runs.Where(s => s.Date >= startDate && s.Date <= endDate);

            }

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

                var loggedin = User.Identity.GetUserId();

                var runs = from m in db.Runs
                           select m;

                runs = runs.Where(s => s.RunId.ToString() == loggedin);

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

        [HttpPost]
        [Route("/calculateavgpace")]
        public decimal CalculateAvgPace(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var loggedin = User.Identity.GetUserId();

                var runs = from m in db.Runs
                           select m;

                runs = runs.Where(s => s.RunId.ToString() == loggedin);

                if (startDate != null && endDate != null)
                {
                    runs = runs.Where(s => s.Date >= startDate && s.Date <= endDate);

                    var averagePace = runs.Select(s => s.Time).ToList();
                    decimal totalTime = averagePace.Sum();
                    var totalDistance = runs.Select(s => s.Distance).ToList();
                    decimal TotalDistance = totalDistance.Sum();
                    ViewBag.ap = Math.Round(totalTime / TotalDistance, 2);
                }
                return ViewBag.ap;
            }
            catch
            {
                throw new Exception("Please enter the dates.");
            }
        }

        [Route("/calculateavgheart")]
        public int CalculateAvgHeart(DateTime startDate, DateTime endDate)
        {
            try
            {
                var loggedin = User.Identity.GetUserId();

                var runs = from m in db.Runs
                           select m;

                runs = runs.Where(s => s.RunId.ToString() == loggedin);


                if (startDate != null && endDate != null)
                {
                    runs = runs.Where(s => s.Date >= startDate && s.Date <= endDate);


                    var averageHeart = runs.Select(s => s.HeartRate).ToList();
                    var days = averageHeart.Count;
                    int totalHeart = averageHeart.Sum();
                    
                    ViewBag.ah = totalHeart / days;
                }
                return ViewBag.ah;
            }
            catch 
            {
                
                throw new Exception("Please enter the dates.");
                
            }

           
        }

        public ActionResult Pace()
        {
          

            return View();
        }

        [HttpPost]
        [Route("/calculatepace")]
        public decimal CalculatePace(string distance, string time)
        {
            
            decimal Distance = Convert.ToDecimal(distance);
            decimal Time = Convert.ToDecimal(time);
            decimal pace = Math.Round( Time / Distance, 2); 
            return pace;
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
