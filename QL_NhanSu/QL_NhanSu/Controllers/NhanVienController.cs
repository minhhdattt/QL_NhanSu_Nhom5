using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;



namespace QL_NhanSu.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult NhanVien()
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 2 || tk.Allower == 4)
            {
                IQueryable<NhanVien> nv = data.NhanViens;
                return View(nv.ToList().OrderBy(n => n.MaNV));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }
        public ActionResult ChitietNhanVien(int id)
        {
            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == id);
            ViewBag.MaNV = nv.MaNV;
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nv);
        }
        [HttpGet]
        public ActionResult XoaNhanVien(int id)
        {
            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == id);
            ViewBag.MaNV = nv.MaNV;
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nv);
        }
        [HttpPost, ActionName("XoaNhanVien")]
        public ActionResult Xacnhanxoa(int id)
        {
            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == id);
            ViewBag.MaNV = nv.MaNV;
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.XoaNhanVien(nv.MaNV);
            data.SubmitChanges();
            return RedirectToAction("NhanVien");
        }
        [HttpGet]
        public ActionResult LapHopDong(int id)
        {
            //NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == id);
            //ViewBag.MaNV = nv.MaNV;
            //if (nv == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            return View();
        }
        [HttpPost, ActionName("LapHopDong")]
        public ActionResult XacnhanHD(int id, HopDongTD hd,FormCollection f)
        {
            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == id);
            hd.Ngay = DateTime.Now;
            hd.ThoiHan = Convert.ToInt32(f["Thoihan"]);
            if (Convert.ToInt32(f["Thoihan"]) <= 12)
            {
                hd.Loai = "Ngắn hạn";
            }
            else
            {
                hd.Loai = "Dài hạn";
            }
            data.HopDongTDs.InsertOnSubmit(hd);
            data.SubmitChanges();

            nv.TinhTrang = "Chính thức";
            nv.MaHD = hd.MaHD;
            data.SubmitChanges();
            return RedirectToAction("NhanVien", "NhanVien");
        }
    }
}