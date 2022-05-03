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
                insuree.Quote = 50.0m; // $50 base quote amount for all customers added to quote                                                      
                int age = DateTime.Now.Year - insuree.DateOfBirth.Year; //calculating user age

                if (age < 18) // if user is under 18 add $100, over 19 and under 25 add $50, over 25 add $25
                {
                    decimal newQuoteAmount = insuree.Quote + 100.00m; //add $100 to total if under 18
                    insuree.Quote = newQuoteAmount;
                }
                else if (age >= 19 && age <= 25)
                {
                    decimal newQuoteAmount = insuree.Quote + 50.00m; //add $50 to total if over 19 and under 25 years old
                    insuree.Quote = newQuoteAmount;
                }
                else
                {
                    decimal newQuoteAmount = insuree.Quote + 25.00m; //add $25 to total if over 25 years old
                    insuree.Quote = newQuoteAmount;
                }
                if (insuree.CarYear < 2000)
                {
                    decimal newQuoteAmount = insuree.Quote + 25.00m; //add $25 to total if car year before 2000
                    insuree.Quote = newQuoteAmount;
                }
                if (insuree.CarMake == "Porsche")
                {
                    decimal newQuoteAmount = insuree.Quote + 25.00m; //add $25 if car make porsche
                    insuree.Quote = newQuoteAmount;
                }
                if (insuree.CarModel == "911 Carrera")
                {
                    decimal newQuoteAmount = insuree.Quote + 25.00m; //add $25 to total if Car model is 911 carrera
                    insuree.Quote = newQuoteAmount;
                }
                if (insuree.DUI == true)
                { 
                    insuree.Quote = insuree.Quote + (insuree.Quote * .25m);
                    //add 25% to quote if user has had DUI
                }

            
                if (insuree.SpeedingTickets > 0)
                {
                    decimal fee = insuree.SpeedingTickets * 10.00m; //adding $10 per speeding ticket to quote
                    decimal newQuoteAmount = insuree.Quote + fee;
                    insuree.Quote = newQuoteAmount;
                }
                if (insuree.CoverageType == true)
                {
                    insuree.Quote = insuree.Quote + (insuree.Quote * .50m);
                    //add 25% to quote if user has full coverage
                }
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
            return View(db.Insurees.ToList()); //returning new list to view                        
        }
    }
}
