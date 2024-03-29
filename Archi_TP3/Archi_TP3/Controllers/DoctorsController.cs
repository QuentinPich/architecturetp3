﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Archi_TP3.Models;

namespace Archi_TP3.Controllers
{
    public class DoctorsController : Controller
    {
        private Context db = new Context();

        // GET: Doctors
        public ActionResult Index()
        {
            var doctor = db.Doctor.Include(d => d.DoctorType).Include(d => d.Employee);
            return View(doctor.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.DoctorTypeID = new SelectList(db.DoctorTypes, "DoctorTypeID", "Label");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastNameEmployee");
            return View();
        }

        // POST: Doctors/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorID,EmployeeID,DoctorTypeID")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctor.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorTypeID = new SelectList(db.DoctorTypes, "DoctorTypeID", "Label", doctor.DoctorTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastNameEmployee", doctor.EmployeeID);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorTypeID = new SelectList(db.DoctorTypes, "DoctorTypeID", "Label", doctor.DoctorTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastNameEmployee", doctor.EmployeeID);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorID,EmployeeID,DoctorTypeID")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorTypeID = new SelectList(db.DoctorTypes, "DoctorTypeID", "Label", doctor.DoctorTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastNameEmployee", doctor.EmployeeID);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            db.Doctor.Remove(doctor);
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
