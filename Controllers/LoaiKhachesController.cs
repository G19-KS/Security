using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiKS.Models;

namespace QuanLiKS.Controllers
{
    public class LoaiKhachesController : Controller
    {
        private KhachSanContext db = new KhachSanContext();

        // GET: LoaiKhaches
        public ActionResult Index()
        {
            return View(db.LoaiKhaches.ToList());
        }

        // GET: LoaiKhaches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiKhach loaiKhach = db.LoaiKhaches.Find(id);
            if (loaiKhach == null)
            {
                return HttpNotFound();
            }
            return View(loaiKhach);
        }

        // GET: LoaiKhaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiKhaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiKhach,TenLoaiKhach")] LoaiKhach loaiKhach)
        {
            if (ModelState.IsValid)
            {
                db.LoaiKhaches.Add(loaiKhach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiKhach);
        }

        // GET: LoaiKhaches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiKhach loaiKhach = db.LoaiKhaches.Find(id);
            if (loaiKhach == null)
            {
                return HttpNotFound();
            }
            return View(loaiKhach);
        }

        // POST: LoaiKhaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiKhach,TenLoaiKhach")] LoaiKhach loaiKhach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiKhach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiKhach);
        }

        // GET: LoaiKhaches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiKhach loaiKhach = db.LoaiKhaches.Find(id);
            if (loaiKhach == null)
            {
                return HttpNotFound();
            }
            return View(loaiKhach);
        }

        // POST: LoaiKhaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiKhach loaiKhach = db.LoaiKhaches.Find(id);
            db.LoaiKhaches.Remove(loaiKhach);
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
