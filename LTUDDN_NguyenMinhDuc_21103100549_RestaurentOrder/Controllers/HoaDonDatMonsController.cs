using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTUDDN_NguyenMinhDuc_21103100549_RestaurentOrder.Models;

namespace LTUDDN_NguyenMinhDuc_21103100549_RestaurentOrder.Controllers
{
    public class HoaDonDatMonsController : Controller
    {
        private QLHDDataContext db = new QLHDDataContext();

        // GET: HoaDonDatMons
        public ActionResult Index()
        {
            var hoaDonDatMons = db.HoaDonDatMons.Include(h => h.MonAn);
            return View(hoaDonDatMons.ToList());
        }

        // GET: HoaDonDatMons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMons/Create
        public ActionResult Create()
        {
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon");
            return View();
        }

        // POST: HoaDonDatMons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaMon,KhachHang,NgayDat,SoLuong")] HoaDonDatMon hoaDonDatMon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonDatMons.Add(hoaDonDatMon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // POST: HoaDonDatMons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaMon,KhachHang,NgayDat,SoLuong")] HoaDonDatMon hoaDonDatMon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonDatMon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // GET: HoaDonDatMons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDatMon);
        }

        // POST: HoaDonDatMons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonDatMon hoaDonDatMon = db.HoaDonDatMons.Find(id);
            db.HoaDonDatMons.Remove(hoaDonDatMon);
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

        public ActionResult Index(string searchString)
        {
            var hoaDon = db.HoaDonDatMons.Include("MonAn").AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                hoaDon = hoaDon.Where(hd => hd.KhachHang.Contains(searchString));
            }

            return View(hoaDon.ToList());
        }
    }
}
