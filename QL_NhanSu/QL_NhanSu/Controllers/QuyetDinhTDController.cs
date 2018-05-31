using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;

namespace QL_NhanSu.Controllers
{
    public class QuyetDinhTDController : Controller
    {
        // GET: QuyetDinhTD
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult QuyetDinhTD(int? page, string searchStr)
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 1 || tk.Allower == 4)
            {
                List<QuyetDinhTD> td = data.QuyetDinhTDs.ToList();
                return View(td.ToList().OrderBy(n => n.MaQD));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }
        [HttpGet]
        public ActionResult ThemQDmoi()
        {
            ViewBag.MaPB = new SelectList(data.PhongBans.ToList().OrderBy(n => n.TenPhongBan), "MaPB", "TenPhongBan");
            ViewBag.MaCV = new SelectList(data.ChucVus.ToList().OrderBy(n => n.TenChucVu), "MaCV", "TenChucVu");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemQDmoi(QuyetDinhTD td)
        {
            ViewBag.MaPB = new SelectList(data.PhongBans.ToList().OrderBy(n => n.TenPhongBan), "MaPB", "TenPhongBan");
            ViewBag.MaCV = new SelectList(data.ChucVus.ToList().OrderBy(n => n.TenChucVu), "MaCV", "TenChucVu");
            if (ModelState.IsValid)
            {
                td.Ngaycapnhat = DateTime.Now;
                td.TrangThai = "Còn tuyển";
                data.QuyetDinhTDs.InsertOnSubmit(td);
                data.SubmitChanges();
                return RedirectToAction("QuyetDinhTD");
            }
            else
            {
                ModelState.AddModelError(" ", "Thêm thất bại");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SuaQuyetDinh(int id)
        {

            QuyetDinhTD td = data.QuyetDinhTDs.SingleOrDefault(n => n.MaQD == id);
            ViewBag.MaQD = td.MaQD;
            if (td == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //ViewBag.MaPB = new SelectList(data.PhongBans.ToList().OrderBy(n => n.TenPhongBan), "MaPB", "TenPhongBan");
            //ViewBag.MaCV = new SelectList(data.ChucVus.ToList().OrderBy(n => n.TenChucVu), "MaCV", "TenChucVu");
            //var cv = data.ChucVus.SingleOrDefault(n => n.MaCV == td.MaCV);
            //ViewBag.Time = cv.ThoiGianThuViec;
            //ViewBag.ThuViec = cv.MucLuongThuViec;
            //ViewBag.CT = cv.MucLuongCT;
            //ViewBag.PhuCap = cv.PhuCap;
            return View(td);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaQuyetDinh(QuyetDinhTD td)
        {
            //ViewBag.MaPB = new SelectList(data.PhongBans.ToList().OrderBy(n => n.TenPhongBan), "MaPB", "TenPhongBan");
            //ViewBag.MaCV = new SelectList(data.ChucVus.ToList().OrderBy(n => n.TenChucVu), "MaCV", "TenChucVu");
            QuyetDinhTD qd = data.QuyetDinhTDs.ToList().Find(n => n.MaQD == td.MaQD);
            //var cv = data.ChucVus.SingleOrDefault(n => n.MaCV == qd.MaCV);
            //ViewBag.Time = cv.ThoiGianThuViec;
            //ViewBag.ThuViec = cv.MucLuongThuViec;
            //ViewBag.CT = cv.MucLuongCT;
            //ViewBag.PhuCap = cv.PhuCap;

            if (ModelState.IsValid)
            {
                
                
                qd.Mota = td.Mota;
                qd.SoLuong = td.SoLuong;
                qd.Ngaycapnhat = DateTime.Now;
                data.SubmitChanges();
                return RedirectToAction("QuyetDinhTD");
            }
            else
            {
                ModelState.AddModelError(" ", "Sửa thất bại");
            }
            return View();
        }

        public ActionResult ChitietQuyetDinh(int id)
        {
            QuyetDinhTD td = data.QuyetDinhTDs.SingleOrDefault(n => n.MaQD == id);
            ViewBag.MaQD = td.MaQD;
            if (td == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(td);
        }

        //[HttpGet]
        //public ActionResult XoaQuyetDinh(int id)
        //{
        //    QuyetDinhTD td = data.QuyetDinhTDs.SingleOrDefault(n => n.MaQD == id);
        //    ViewBag.MaQD = td.MaQD;
        //    if (td == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(td);
        //}
        //[HttpPost, ActionName("XoaQuyetDinh")]
        //public ActionResult Xacnhanxoa(int id)
        //{
        //    QuyetDinhTD td = data.QuyetDinhTDs.SingleOrDefault(n => n.MaQD == id);
        //    ViewBag.MaQD = td.MaQD;
        //    if (td == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    data.QuyetDinhTDs.DeleteOnSubmit(td);
        //    data.SubmitChanges();
        //    return RedirectToAction("QuyetDinhTD");
        //}
    }
}