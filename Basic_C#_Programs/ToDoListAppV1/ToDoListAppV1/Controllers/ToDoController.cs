using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoListApp.DAL;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class ToDoController : Controller
    {
        private ToDoContext db = new ToDoContext();

        // GET: ToDo
        public ActionResult Index(string searchTerm)
        {
            var resultsListItem = from x in db.ToDos select x;
            ViewBag.Showlist = false;
            if (!String.IsNullOrEmpty(searchTerm))
            {
                ViewBag.ShowList = true;
                resultsListItem = resultsListItem.Where(x => x.ToDoListItem.ToUpper().Contains(searchTerm.ToUpper()));
                
                if (resultsListItem.Any() == true)
                {
                    return View(resultsListItem);
                }
                else
                {
                    return View(db.ToDos.ToList());
                }
            }
            else
            {
                ViewBag.ShowList = true;
                return View(db.ToDos.ToList());
            }
            
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ToDoListItem")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.ToDos.Add(toDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDo);
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        // POST: ToDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ToDoListItem")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDo);
        }

        // GET: ToDo/Delete/5


        public ActionResult Delete(int id)
        {
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            db.ToDos.Remove(toDo);
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
