using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstaAlbum.Models;

namespace InstaAlbum.Controllers
{
    public class StudioAdminsController : Controller
    {
        private InstaAlbumEntities db = new InstaAlbumEntities();


        public List<tblStudioAdmin> getAllAdmin()
        {
            return db.tblStudioAdmins.ToList();
        }

        // GET: StudioAdmins
        public ActionResult Index()
        {
            return View(db.tblStudioAdmins.ToList());
        }

        // GET: StudioAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudioAdmin tblStudioAdmin = db.tblStudioAdmins.Find(id);
            if (tblStudioAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tblStudioAdmin);
        }

        // GET: StudioAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudioAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudioID,StudioName,Address,Email,Password,PhoneNo,StudioLogo,About,OpeningHours,ClosingHours,Map,IsActive,CreatedDate")] tblStudioAdmin tblStudioAdmin)
        {
            if (ModelState.IsValid)
            {
                tblStudioAdmin.CreatedDate = DateTime.Now;
                db.tblStudioAdmins.Add(tblStudioAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStudioAdmin);
        }

        // GET: StudioAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudioAdmin tblStudioAdmin = db.tblStudioAdmins.Find(id);
            if (tblStudioAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tblStudioAdmin);
        }

        // POST: StudioAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudioID,StudioName,Address,Email,Password,PhoneNo,StudioLogo,About,OpeningHours,ClosingHours,Map,IsActive,UpdatedDate")] tblStudioAdmin tblStudioAdmin)
        {
            if (ModelState.IsValid)
            {
                tblStudioAdmin.UpdatedDate = DateTime.Now;
                db.Entry(tblStudioAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStudioAdmin);
        }

        // GET: StudioAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudioAdmin tblStudioAdmin = db.tblStudioAdmins.Find(id);
            if (tblStudioAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tblStudioAdmin);
        }

        // POST: StudioAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStudioAdmin tblStudioAdmin = db.tblStudioAdmins.Find(id);
            db.tblStudioAdmins.Remove(tblStudioAdmin);
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
