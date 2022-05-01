using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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
        
        public ActionResult Admin()
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                DateTime ageCutOff18 = DateTime.Now.AddYears(-18); // creating each datetime object for use in lambda expressions
                DateTime ageCuttOff19 = DateTime.Now.AddYears(-19); // for age quote rate value scale
                DateTime ageCuttOff25 = DateTime.Now.AddYears(-25);
                Decimal monthlyBase = 50.00m; //base dollar amount to charge for quote
                var QuoteTotals = new List<Insuree>(); // list to add to for multiple all objects to be displayed
                var insuree = new Insuree(); // object to add to above list after quote rates are calculated
                foreach (var ActiveCust in db.Insurees)
                {
                    var Under18 = db.Insurees.Where(x => x.DateOfBirth > ageCutOff18).ToList();
                    foreach (var custInsuree in Under18)
                    {
                        if (custInsuree.DateOfBirth > ageCutOff18)
                        {
                            decimal fee = 100.00m; //add $100 to total if under 18
                            decimal monthlyBase18 = custInsuree.Quote + fee; //adding in fee to Insuree quote
                            custInsuree.Quote = monthlyBase18;
                        }
                    }
                    var Under19below25 = db.Insurees.Where(x => x.DateOfBirth <= ageCuttOff19 && x.DateOfBirth >= ageCuttOff25).ToList();
                    foreach (var custInsuree in Under19below25)
                    {
                        if (custInsuree.DateOfBirth <= ageCuttOff19 && custInsuree.DateOfBirth >= ageCuttOff25)
                        {
                            decimal fee = 50.00m; //add $50 to total if over 19 and under 25 years old
                            decimal monthlyBase19_25 = custInsuree.Quote + fee;
                            custInsuree.Quote = monthlyBase19_25;
                        }
                    }
                    var Over25 = db.Insurees.Where(x => x.DateOfBirth < ageCuttOff25).ToList();
                    foreach (var custInsuree in Over25)
                    {
                        if (custInsuree.DateOfBirth < ageCuttOff25)
                        {
                            decimal fee = 25.00m; //add $25 to total if over 25 years old
                            decimal monthlyBaseOver25 = custInsuree.Quote + fee;
                            custInsuree.Quote = monthlyBaseOver25;
                        }
                    }
                    var carYearBefore = db.Insurees.Where(x => x.CarYear < 2000).ToList();
                    foreach (var custInsuree in carYearBefore)
                    {
                        if (custInsuree.CarYear > 2000)
                        {
                            decimal fee = 25.00m; //add $25 to total if car year is before year 2000
                            decimal monthlyBaseCarYearBefore = custInsuree.Quote + fee;
                            custInsuree.Quote = monthlyBaseCarYearBefore;
                        }
                    }
                    var CarMakePorsche = db.Insurees.Where(x => x.CarMake == "Porsche").ToList();
                    foreach (var custInsuree in CarMakePorsche)
                    {
                        if (custInsuree.CarMake == "Porsche")
                        {
                            decimal fee = 25.00m; //add $25 to total if car is make porsche
                            decimal monthlyBaseCarMakePorsche = custInsuree.Quote + fee;
                            custInsuree.Quote = monthlyBaseCarMakePorsche;
                        }
                    }
                    var CarModelCarrera = db.Insurees.Where(x => x.CarModel == "911 Carrera").ToList();
                    foreach (var custInsuree in CarModelCarrera)
                    {
                        if (custInsuree.CarModel == "911 Carrera")
                        {
                            decimal fee = 25.00m; //add $25 to total if Car model is 911 carrera
                            decimal monthlyBaseCarMakePorsche = custInsuree.Quote + fee;
                            custInsuree.Quote = monthlyBaseCarMakePorsche;
                        }
                    }
                    var SpeedTicketCount = db.Insurees.Where(x => x.SpeedingTickets > 0).ToList();
                    foreach (var custInsuree in SpeedTicketCount)
                    {
                        if (custInsuree.SpeedingTickets > 0)
                        {
                            decimal fee = custInsuree.SpeedingTickets * 10.00m; //adding $10 per speeding ticket to quote
                            decimal monthlyBaseCarMakePorsche = custInsuree.Quote + fee;
                            custInsuree.Quote = monthlyBaseCarMakePorsche;
                        }
                    }
                    var FullCoverage = db.Insurees.Where(x => x.CoverageType == true);
                    foreach (var custInsuree in FullCoverage)
                    {
                        if (custInsuree.CoverageType == true)
                        {
                            decimal fee = .50m; // add 50 percent to quote if full coverage checked
                            decimal monthlyBaseFullCov = custInsuree.Quote * fee;
                            custInsuree.Quote = monthlyBaseFullCov;
                        }
                    }
                    insuree.Id = ActiveCust.Id;  // mapping properties between objects for display
                    insuree.FirstName = ActiveCust.FirstName;
                    insuree.LastName = ActiveCust.LastName;
                    insuree.EmailAddress = ActiveCust.EmailAddress;
                    insuree.DateOfBirth = ActiveCust.DateOfBirth;
                    insuree.CarYear = ActiveCust.CarYear;
                    insuree.CarMake = ActiveCust.CarMake;
                    insuree.CarModel = ActiveCust.CarModel;
                    insuree.DUI = ActiveCust.DUI;
                    insuree.SpeedingTickets = ActiveCust.SpeedingTickets;
                    insuree.CoverageType = ActiveCust.CoverageType;
                    insuree.Quote = ActiveCust.Quote;
                    QuoteTotals.Add(insuree);
                    decimal addBase = insuree.Quote + monthlyBase; //adding in monthly base quote amount $50
                    insuree.Quote = addBase;
                }

                return View(QuoteTotals); //returning new list to view
                //return View(db.Insurees.ToList());  // verified method is returning to correct view and will popualate info, problem must be with my method 
            }
        }
    }
}
