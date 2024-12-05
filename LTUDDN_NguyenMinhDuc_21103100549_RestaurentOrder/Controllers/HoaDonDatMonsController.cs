using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using LTUDDN_NguyenMinhDuc_21103100549_RestaurentOrder.Models;

namespace LTUDDN_NguyenMinhDuc_21103100549_RestaurentOrder.Controllers
{
    public class HoaDonDatMonsController : Controller
    {
        private QLHDDataContext db = new QLHDDataContext();

        // GET: HoaDonDatMons
        public ActionResult Index(string searchString)
        {
            var hoaDon = db.HoaDonDatMons.Include(h => h.MonAn).AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                hoaDon = hoaDon.Where(hd => hd.KhachHang.Contains(searchString));
            }

            return View(hoaDon.ToList());
        }

        // GET: HoaDonDatMons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var hoaDonDatMon = db.HoaDonDatMons.AsNoTracking().FirstOrDefault(hd => hd.MaHD == id);

            if (hoaDonDatMon == null)
            {
                return HttpNotFound("Không tìm thấy hóa đơn.");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaMon,KhachHang,NgayDat,SoLuong")] HoaDonDatMon hoaDonDatMon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonDatMons.Add(hoaDonDatMon);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Tạo mới hóa đơn thành công.";
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

            var hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound("Không tìm thấy hóa đơn để chỉnh sửa.");
            }

            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDonDatMon.MaMon);
            return View(hoaDonDatMon);
        }

        // POST: HoaDonDatMons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaMon,KhachHang,NgayDat,SoLuong")] HoaDonDatMon hoaDonDatMon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonDatMon).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Cập nhật hóa đơn thành công.";
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

            var hoaDonDatMon = db.HoaDonDatMons.Find(id);
            if (hoaDonDatMon == null)
            {
                return HttpNotFound("Không tìm thấy hóa đơn để xóa.");
            }

            return View(hoaDonDatMon);
        }

        // POST: HoaDonDatMons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hoaDonDatMon = db.HoaDonDatMons.Find(id);

            if (hoaDonDatMon != null)
            {
                db.HoaDonDatMons.Remove(hoaDonDatMon);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Xóa hóa đơn thành công.";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể xóa hóa đơn, dữ liệu không tồn tại.";
            }

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

        // GET: HoaDonDatMons
        public ActionResult Index2(string searchString)
        {
            var hoaDonDatMons = from h in db.HoaDonDatMons
                                select h;

            if (!String.IsNullOrEmpty(searchString))
            {
                hoaDonDatMons = hoaDonDatMons.Where(h => h.KhachHang.Contains(searchString));
            }

            return View(hoaDonDatMons.ToList());
        }

        public ActionResult TopHoaDon()
        {
            // Lấy hóa đơn có tổng thành tiền cao nhất
            var topHoaDon = db.HoaDonDatMons
                .Join(db.MonAns,
                      hd => hd.MaMon,
                      ma => ma.MaMon,
                      (hd, ma) => new
                      {
                          HoaDon = hd,
                          TenMon = ma.TenMon,
                          ThanhTien = hd.SoLuong * ma.DonGia
                      })
                .OrderByDescending(bill => bill.ThanhTien)
                .FirstOrDefault();

            if (topHoaDon == null)
            {
                return HttpNotFound("Không có hóa đơn nào.");
            }

            // Truyền dữ liệu cần thiết qua ViewBag
            ViewBag.TenMon = topHoaDon.TenMon;
            ViewBag.ThanhTien = topHoaDon.ThanhTien;

            // Trả về view với dữ liệu hóa đơn
            return View(topHoaDon.HoaDon);
        }

    }
}

