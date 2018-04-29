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
    public class PhongThuesController : Controller
    {
        private KhachSanContext db = new KhachSanContext();

        // GET: PhongThues
        public ActionResult Index()
        {
            var phongThues = db.PhongThues.Include(p => p.Phong);
            return View(phongThues.ToList());
        }

        // GET: PhongThues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongThue phongThue = db.PhongThues.Find(id);
            if (phongThue == null)
            {
                return HttpNotFound();
            }
            return View(phongThue);
        }

        // GET: PhongThues/Create
        public ActionResult Create()
        {

           // SelectList(db.Users.Where(g => g.UserName == userName).ToList()
              
            //ViewBag.HoaDons = new SelectList(db.HoaDons, "SoHD", "SoHD");
            ViewBag.MaPhong = new SelectList(db.Phongs.Where(p=>p.TinhTrang==false) , "MaPhong", "MaPhong");
            ViewBag.SoHD = new SelectList(db.HoaDons, "SoHD", "SoHD");
            return View();
        }

        // POST: PhongThues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThue,SoHD,MaPhong,NgayDen,NgayDi,SoLuong")] PhongThue phongThue)
        {
            if (ModelState.IsValid)
            {
                ChiTietHD cthd = new ChiTietHD();
                int soNgay = cthd.SoNgay(Convert.ToDateTime(phongThue.NgayDen), Convert.ToDateTime(phongThue.NgayDi));
                Phong p = db.Phongs.Find(phongThue.MaPhong);
                int tien = Convert.ToInt32(db.LoaiPhongs.Find(p.MaLoaiPhong).Gia);

                int makhach = Convert.ToInt32(db.HoaDons.Find(phongThue.SoHD).MaKH);
                p.TinhTrang = true;
                db.PhongThues.Add(phongThue);                
                cthd.SoNgayO = soNgay;
                cthd.MaThue = phongThue.MaThue;
                cthd.SoHD = Convert.ToInt32(phongThue.SoHD);
               
                int slKhach = Convert.ToInt32(db.PhongThues.Find(cthd.MaThue).SoLuong);
                if (db.KhachHangs.Find(makhach).MaLoaiKhach == "NN")
                {
                    if (slKhach > 2)
                    {
                        cthd.Tien = ((tien * 3 / 2) + ((tien * 3 / 2) / 4)) * soNgay;
                        db.ChiTietHDs.Add(cthd);
                        db.SaveChanges();
                    }
                    else
                    {
                        cthd.Tien = (tien * 3 / 2) * soNgay;
                        db.ChiTietHDs.Add(cthd);
                        db.SaveChanges();
                    }
                }
                else
                {
                   
                    if (slKhach > 2)
                    {
                        cthd.Tien = (tien + tien / 4) * soNgay;
                        db.ChiTietHDs.Add(cthd);
                        db.SaveChanges();
                    }
                    else
                    {
                        cthd.Tien = (tien) * soNgay;
                        db.ChiTietHDs.Add(cthd);
                        db.SaveChanges();
                    }
                }
                                
                return RedirectToAction("Index", "ChiTietHDs");
            }

            ViewBag.SoHD = new SelectList(db.HoaDons, "SoHd", "SoHD", phongThue.SoHD);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong", phongThue.MaPhong);
            return View(phongThue);
        }

        // GET: PhongThues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongThue phongThue = db.PhongThues.Find(id);
            if (phongThue == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong", phongThue.MaPhong);
            return View(phongThue);
        }

        // POST: PhongThues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThue,SoHD,MaPhong,NgayDen,NgayDi,SoLuong")] PhongThue phongThue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongThue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong", phongThue.MaPhong);
            return View(phongThue);
        }

        // GET: PhongThues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongThue phongThue = db.PhongThues.Find(id);
            if (phongThue == null)
            {
                return HttpNotFound();
            }
            return View(phongThue);
        }

        // POST: PhongThues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongThue phongThue = db.PhongThues.Find(id);
            db.PhongThues.Remove(phongThue);
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
