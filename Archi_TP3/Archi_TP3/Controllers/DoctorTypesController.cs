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
    public class DoctorTypesController : Controller
    {
        private Context db = new Context();

        // GET: DoctorTypes
        public ActionResult Index()
        {
            var doctorTypes = db.DoctorTypes.Include(d => d.Reason);
            return View(doctorTypes.ToList());
        }

        // GET: DoctorTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorType doctorType = db.DoctorTypes.Find(id);
            if (doctorType == null)
            {
                return HttpNotFound();
            }
            return View(doctorType);
        }

        // GET: DoctorTypes/Create
        public ActionResult Create()
        {
            ViewBag.ReasonID = new SelectList(db.Reasons, "ReasonID", "Label");
            return View();
        }

        // POST: DoctorTypes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorTypeID,ReasonID,Label")] DoctorType doctorType)
        {
            if (ModelState.IsValid)
            {
                db.DoctorTypes.Add(doctorType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReasonID = new SelectList(db.Reasons, "ReasonID", "Label", doctorType.ReasonID);
            return View(doctorType);
        }

        // GET: DoctorTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorType doctorType = db.DoctorTypes.Find(id);
            if (doctorType == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReasonID = new SelectList(db.Reasons, "ReasonID", "Label", doctorType.ReasonID);
            return View(doctorType);
        }

        // POST: DoctorTypes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorTypeID,ReasonID,Label")] DoctorType doctorType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReasonID = new SelectList(db.Reasons, "ReasonID", "Label", doctorType.ReasonID);
            return View(doctorType);
        }

        // GET: DoctorTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorType doctorType = db.DoctorTypes.Find(id);
            if (doctorType == null)
            {
                return HttpNotFound();
            }
            return View(doctorType);
        }

        // POST: DoctorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorType doctorType = db.DoctorTypes.Find(id);
            db.DoctorTypes.Remove(doctorType);
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
