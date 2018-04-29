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
    public class ChiTietHDsController : Controller
    {
        private KhachSanContext db  = new KhachSanContext();

        // GET: ChiTietHDs
        public ActionResult Index()
        {
            var chiTietHDs = db.ChiTietHDs.Include(c => c.HoaDon).Include(c => c.PhongThue);
            return View(chiTietHDs.ToList());
        }

        // GET: ChiTietHDs/Details/5
        [HttpGet]
        public ActionResult TinhTien(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }


        public JsonResult ThanhToan(int? sohd)
        {

            Phong p = db.ChiTietHDs.Find(sohd).PhongThue.Phong;
            p.TinhTrang = false;
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        // GET: ChiTietHDs/Create
        public ActionResult Create()
        {
            ViewBag.SoHD = new SelectList(db.HoaDons, "SoHD", "SoHD");
            ViewBag.MaThue = new SelectList(db.PhongThues, "MaThue", "MaThue");
            return View();
        }

        // POST: ChiTietHDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCTHD,SoHD,MaThue,SoNgayO,Tien")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHDs.Add(chiTietHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SoHD = new SelectList(db.HoaDons, "SoHD", "SoHD", chiTietHD.SoHD);
            ViewBag.MaThue = new SelectList(db.PhongThues, "MaThue", "MaThue", chiTietHD.MaThue);
            return View(chiTietHD);
        }

        // GET: ChiTietHDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            ViewBag.SoHD = new SelectList(db.HoaDons, "SoHD", "SoHD", chiTietHD.SoHD);
            ViewBag.MaThue = new SelectList(db.PhongThues, "MaThue", "MaThue", chiTietHD.MaThue);
            return View(chiTietHD);
        }

        // POST: ChiTietHDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCTHD,SoHD,MaThue,SoNgayO,Tien")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SoHD = new SelectList(db.HoaDons, "SoHD", "SoHD", chiTietHD.SoHD);
            ViewBag.MaThue = new SelectList(db.PhongThues, "MaThue", "MaThue", chiTietHD.MaThue);
            return View(chiTietHD);
        }

        // GET: ChiTietHDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // POST: ChiTietHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            db.ChiTietHDs.Remove(chiTietHD);
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
