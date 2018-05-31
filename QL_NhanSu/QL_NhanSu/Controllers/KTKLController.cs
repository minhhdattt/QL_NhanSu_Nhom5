using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;


namespace QL_NhanSu.Controllers
{
    public class KTKLController : Controller
    {
        // GET: KTKL
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult KTKL()
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 2 || tk.Allower == 4)
            {
                List<KT_KL> ktkl = data.KT_KLs.ToList();
                return View(ktkl.ToList().OrderBy(n => n.MaNV));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }
        [HttpGet]
        public ActionResult ThemKTKLmoi()
        {
            ViewBag.MaNV = new SelectList(data.NhanViens.ToList().OrderBy(n => n.MaNV), "MaNV", "MaNV");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemKTKLmoi(KT_KL ktkl, FormCollection collection)
        {
            var loai = collection["Loai"];
            ViewBag.MaNV = new SelectList(data.NhanViens.ToList().OrderBy(n => n.MaNV), "MaNV", "MaNV");

            if (ModelState.IsValid)
            {
                ktkl.Loai = loai;
                ktkl.Ngay = DateTime.Now;
                ktkl.TrangThai = "Đang xử lý";
                data.KT_KLs.InsertOnSubmit(ktkl);
                data.SubmitChanges();
                return RedirectToAction("KTKL");
            }
            else
            {
                ModelState.AddModelError(" ", "Thêm thất bại");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SuaKTKL(int id)
        {

            KT_KL ktkl = data.KT_KLs.SingleOrDefault(n => n.MaKT_KL == id);
            ViewBag.MaKTKL = ktkl.MaKT_KL;
            if (ktkl == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaNV = new SelectList(data.NhanViens.ToList().OrderBy(n => n.MaNV), "MaNV", "MaNV");
            return View(ktkl);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaKTKL(KT_KL ktkl, FormCollection collection)
        {
            var loai = collection["Loai"];
            ViewBag.MaNV = new SelectList(data.NhanViens.ToList().OrderBy(n => n.MaNV), "MaNV", "MaNV");
            KT_KL kTKL = data.KT_KLs.ToList().Find(n => n.MaKT_KL == ktkl.MaKT_KL);

            if (ModelState.IsValid)
            {
                kTKL.MaNV = ktkl.MaNV;
                kTKL.NoiDung = ktkl.NoiDung;
                kTKL.Loai = loai;
                kTKL.GiaTri = ktkl.GiaTri;
                kTKL.Ngay = DateTime.Now;
                data.SubmitChanges();
                return RedirectToAction("KTKL");
            }
            else
            {
                ModelState.AddModelError(" ", "Sửa thất bại");
            }
            return View();
        }
        public ActionResult ChitietKTKL(int id)
        {
            KT_KL ktkl = data.KT_KLs.SingleOrDefault(n => n.MaKT_KL == id);
            ViewBag.MaKTL = ktkl.MaKT_KL;
            if (ktkl == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ktkl);
        }
        [HttpGet]
        public ActionResult XoaKTKL(int id)
        {
            KT_KL ktkl = data.KT_KLs.SingleOrDefault(n => n.MaKT_KL == id);
            ViewBag.MaKTL = ktkl.MaKT_KL;
            if (ktkl == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ktkl);
        }
        [HttpPost, ActionName("XoaKTKL")]
        public ActionResult Xacnhanxoa(int id)
        {
            KT_KL ktkl = data.KT_KLs.SingleOrDefault(n => n.MaKT_KL == id);
            ViewBag.MaKTL = ktkl.MaKT_KL;
            if (ktkl == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.KT_KLs.DeleteOnSubmit(ktkl);
            data.SubmitChanges();
            return RedirectToAction("KTKL");
        }
    }
}