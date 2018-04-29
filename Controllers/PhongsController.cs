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
    public class PhongsController : Controller
    {
        //  private KhachSanContext db = new KhachSanContext();

        KhachSanContext db = new KhachSanContext();

        // GET: Phongs
        public ActionResult Index()
        {
            var phongs = db.Phongs.ToList();
            //for (int i = 0; i < phongs.Count(); i++)
            //{
            //    phongs[i].TinhTrang = false;
            //}
            return View(phongs);
        }
        public ActionResult DSPhong()
        {
            var phongs = db.Phongs.Include(p => p.LoaiPhong);
            return View(phongs.ToList());
        }

        // GET: Phongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // GET: Phongs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiPhong = new SelectList(db.LoaiPhongs, "MaLoaiPhong", "MaLoaiPhong");
            return View();
        }

        // POST: Phongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhong,MaLoaiPhong,TinhTrang,GhiChu")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Phongs.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiPhong = new SelectList(db.LoaiPhongs, "MaLoaiPhong", "MaLoaiPhong", phong.MaLoaiPhong);
            return View(phong);
        }

        // GET: Phongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiPhong = new SelectList(db.LoaiPhongs, "MaLoaiPhong", "MaLoaiPhong", phong.MaLoaiPhong);
            return View(phong);
        }

        // POST: Phongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhong,MaLoaiPhong,TinhTrang,GhiChu")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiPhong = new SelectList(db.LoaiPhongs, "MaLoaiPhong", "MaLoaiPhong", phong.MaLoaiPhong);
            return View(phong);
        }

        // GET: Phongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // POST: Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phong phong = db.Phongs.Find(id);
            db.Phongs.Remove(phong);
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
