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
    public class BackupsController : Controller
    {
        private KhachSanContext db = new KhachSanContext();

        // GET: Backups
        public ActionResult Index()
        {
            return View(db.BackUps.ToList());
        }
      
        // GET: Backups/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backup backup = db.BackUps.Find(id);
            if (backup == null)
            {
                return HttpNotFound();
            }
            return View(backup);
        }

        // POST: Backups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Backup backup = db.BackUps.Find(id);
            db.BackUps.Remove(backup);
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
