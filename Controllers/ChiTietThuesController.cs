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
    public class ChiTietThuesController : Controller
    {
        private KhachSanContext db = new KhachSanContext();

        // GET: ChiTietThues
        public ActionResult Index()
        {
            var chiTietThues = db.ChiTietThues.Include(c => c.KhachHang).Include(c => c.PhongThue);
            return View(chiTietThues.ToList());
        }

        // GET: ChiTietThues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThue chiTietThue = db.ChiTietThues.Find(id);
            if (chiTietThue == null)
            {
                return HttpNotFound();
            }
            return View(chiTietThue);
        }

        // GET: ChiTietThues/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "MaKH");
            ViewBag.MaThue = new SelectList(db.PhongThues, "MaThue", "MaThue");
            return View();
        }

        // POST: ChiTietThues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,MaThue,HoTen,CMND,MaKH")] ChiTietThue chiTietThue)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietThues.Add(chiTietThue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "MaLoaiKhach", chiTietThue.MaKH);
            ViewBag.MaThue = new SelectList(db.PhongThues, "MaThue", "MaThue", chiTietThue.MaThue);
            return View(chiTietThue);
        }

        // GET: ChiTietThues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThue chiTietThue = db.ChiTietThues.Find(id);
            if (chiTietThue == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "MaLoaiKhach", chiTietThue.MaKH);
            ViewBag.MaThue = new SelectList(db.PhongThues, "MaThue", "MaThue", chiTietThue.MaThue);
            return View(chiTietThue);
        }

        // POST: ChiTietThues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,MaThue,HoTen,CMND,MaKH")] ChiTietThue chiTietThue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietThue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "MaLoaiKhach", chiTietThue.MaKH);
            ViewBag.MaThue = new SelectList(db.PhongThues, "MaThue", "MaThue", chiTietThue.MaThue);
            return View(chiTietThue);
        }

        // GET: ChiTietThues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThue chiTietThue = db.ChiTietThues.Find(id);
            if (chiTietThue == null)
            {
                return HttpNotFound();
            }
            return View(chiTietThue);
        }

        // POST: ChiTietThues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietThue chiTietThue = db.ChiTietThues.Find(id);
            db.ChiTietThues.Remove(chiTietThue);
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
