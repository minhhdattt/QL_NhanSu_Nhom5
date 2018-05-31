using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;

namespace QL_NhanSu.Controllers
{
    public class PhongBanController : Controller
    {
        // GET: PhongBan
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();

        public ActionResult PhongBan()
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 3 || tk.Allower == 4)
            {
                IQueryable<PhongBan> pb = data.PhongBans;
                return View(pb.ToList().OrderBy(n => n.MaPB));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }

        [HttpGet]
        public ActionResult ThemPBmoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemPBmoi(PhongBan pb)
        {
            if (ModelState.IsValid)
            {
                data.PhongBans.InsertOnSubmit(pb);
                data.SubmitChanges();
                return RedirectToAction("PhongBan");
            }
            else
            {
                ModelState.AddModelError(" ", "Thêm thất bại");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SuaPhongBan(string id)
        {
            PhongBan pb = data.PhongBans.SingleOrDefault(n => n.MaPB == id);
            ViewBag.MaPB = pb.MaPB;
            if (pb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(pb);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaPhongBan(PhongBan pb)
        {
            PhongBan phongBan = data.PhongBans.ToList().Find(n => n.MaPB == pb.MaPB);

            if (ModelState.IsValid)
            {
                phongBan.TenPhongBan = pb.TenPhongBan;
                data.SubmitChanges();
                return RedirectToAction("PhongBan");
            }
            else
            {
                ModelState.AddModelError(" ", "Sửa thất bại");
            }
            return View();

        }

        [HttpGet]
        public ActionResult XoaPhongBan(string id)
        {
            PhongBan pb = data.PhongBans.SingleOrDefault(n => n.MaPB == id);
            ViewBag.MaPB = pb.MaPB;
            if (pb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(pb);
        }
        [HttpPost, ActionName("XoaPhongBan")]
        public ActionResult Xacnhanxoa(string id)
        {
            PhongBan pb = data.PhongBans.SingleOrDefault(n => n.MaPB == id);
            ViewBag.MaPB = pb.MaPB;
            if (pb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            data.XoaPhongBan(pb.MaPB);
            data.SubmitChanges();
            return RedirectToAction("PhongBan");
        }
    }
}