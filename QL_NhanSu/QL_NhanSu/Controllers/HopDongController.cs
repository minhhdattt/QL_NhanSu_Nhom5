using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;

namespace QL_NhanSu.Controllers
{
    public class HopDongController : Controller
    {
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        // GET: HopDong
        public ActionResult HopDong()
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 2 || tk.Allower == 4)
            {
                IQueryable<HopDongTD> hd = data.HopDongTDs;
                return View(hd.ToList().OrderBy(n => n.MaHD));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }
        [HttpGet]
        public ActionResult HuyHopDong(int id)
        {
            HopDongTD hd = data.HopDongTDs.SingleOrDefault(n => n.MaHD == id);
            if (hd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hd);
        }
        [HttpPost, ActionName("HuyHopDong")]
        public ActionResult Xacnhanhuy(int id)
        {
            HopDongTD hd = data.HopDongTDs.SingleOrDefault(n => n.MaHD == id);
            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaHD == id);
            if (hd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.XoaNhanVien(nv.MaNV);
            data.SubmitChanges();
            data.HopDongTDs.DeleteOnSubmit(hd);
            data.SubmitChanges();
            return RedirectToAction("HopDong");
        }
        [HttpGet]
        public ActionResult GiahanHopDong(int id)
        {
            HopDongTD hd = data.HopDongTDs.SingleOrDefault(n => n.MaHD == id);
            if (hd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hd);
        }
        [HttpPost]
        public ActionResult GiahanHopDong(int id, HopDongTD hd, FormCollection f)
        {
            HopDongTD hdong = data.HopDongTDs.SingleOrDefault(n => n.MaHD == id);
            if (ModelState.IsValid)
            {
                hdong.Ngay = DateTime.Now;
                hdong.ThoiHan = Convert.ToInt32(f["Thoihan"]);
                if (Convert.ToInt32(f["Thoihan"]) <= 12)
                {
                    hdong.Loai = "Ngắn hạn";
                }
                else
                {
                    hdong.Loai = "Dài hạn";
                }
                data.SubmitChanges();
                return RedirectToAction("HopDong");
            }
            else
            {
                ModelState.AddModelError(" ", "Gia hạn thất bại");
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}