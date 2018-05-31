using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;

namespace QL_NhanSu.Controllers
{
    public class ChucVuController : Controller
    {
        // GET: ChucVu
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult ChucVu()
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 3 || tk.Allower == 4)
            {
                IQueryable<ChucVu> cv = data.ChucVus;
                return View(cv.ToList().OrderBy(n => n.MaCV));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }

        [HttpGet]
        public ActionResult ThemCVmoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemCVmoi(ChucVu cv)
        {
            if (ModelState.IsValid)
            {
                if(cv.PhuCap == null)
                {
                    cv.PhuCap = 0;
                    data.ChucVus.InsertOnSubmit(cv);
                    data.SubmitChanges();
                    return RedirectToAction("ChucVu");
                }
                else
                {
                    data.ChucVus.InsertOnSubmit(cv);
                    data.SubmitChanges();
                    return RedirectToAction("ChucVu");
                }             
            }
            else
            {
                ModelState.AddModelError(" ", "Thêm thất bại");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SuaChucVu(int id)
        {
            ChucVu cv = data.ChucVus.SingleOrDefault(n => n.MaCV == id);
            ViewBag.MaCV = cv.MaCV;
            if (cv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cv);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaChucVu(ChucVu cv)
        {
            ChucVu chucVu = data.ChucVus.ToList().Find(n => n.MaCV == cv.MaCV);

            if (ModelState.IsValid)
            {
                if (chucVu.PhuCap == null)
                {
                    chucVu.TenChucVu = cv.TenChucVu;
                    chucVu.ThoiGianThuViec = cv.ThoiGianThuViec;
                    chucVu.MucLuongThuViec = cv.MucLuongThuViec;
                    chucVu.MucLuongCT = cv.MucLuongCT;
                    cv.PhuCap = 0;
                    data.SubmitChanges();
                    return RedirectToAction("ChucVu");
                }
                else
                {
                    chucVu.TenChucVu = cv.TenChucVu;
                    chucVu.ThoiGianThuViec = cv.ThoiGianThuViec;
                    chucVu.MucLuongThuViec = cv.MucLuongThuViec;
                    chucVu.MucLuongCT = cv.MucLuongCT;
                    chucVu.PhuCap = cv.PhuCap;
                    data.SubmitChanges();
                    return RedirectToAction("ChucVu");
                }                    
            }
            else
            {
                ModelState.AddModelError(" ", "Sửa thất bại");
            }
            return View();

        }

        public ActionResult ChitietChucVu(int id)
        {
            ChucVu cv = data.ChucVus.SingleOrDefault(n => n.MaCV == id);
            ViewBag.MaCV = cv.MaCV;
            if (cv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cv);
        }

        //[HttpGet]
        //public ActionResult XoaChucVu(int id)
        //{
        //    ChucVu cv = data.ChucVus.SingleOrDefault(n => n.MaCV == id);
        //    ViewBag.MaCV = cv.MaCV;
        //    if (cv == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(cv);
        //}
        //[HttpPost, ActionName("XoaChucVu")]
        //public ActionResult Xacnhanxoa(int id)
        //{
        //    ChucVu cv = data.ChucVus.SingleOrDefault(n => n.MaCV == id);
        //    ViewBag.MaCV = cv.MaCV;
        //    if (cv == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    data.ChucVus.DeleteOnSubmit(cv);
        //    data.SubmitChanges();
        //    return RedirectToAction("ChucVu");
        //}
    }
}