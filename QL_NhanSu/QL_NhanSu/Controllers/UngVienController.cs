using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;
using System.Net;
using System.Net.Mail;

namespace QL_NhanSu.Controllers
{
    public class UngVienController : Controller
    {
        // GET: UngVien
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSach()
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 1 || tk.Allower == 4)
            {
                List<DanhSachUV> ds = data.DanhSachUVs.ToList();
                return View(ds.ToList().OrderByDescending(n => n.NgayNop));
            }
            else
            {
                return RedirectToAction("ThongBao","Admin");
            }
            
        }
        public ActionResult ChitietHoSo(int id, int id2)
        {
            DanhSachUV ds = data.DanhSachUVs.SingleOrDefault(n => n.MaQD == id && n.MaUV == id2);
            if (ds == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ds);
        }
        public ActionResult Accept(int id, int id2, NhanVien nv)
        {
            HoSoUngVien hs = data.HoSoUngViens.ToList().Find(n => n.MaUV == id2);
            TaiKhoan tk = data.TaiKhoans.ToList().Find(n => n.MaUV == id2);
            TaiKhoan taiKhoan = data.TaiKhoans.SingleOrDefault(n => n.MaUV == id2);
            nv.HoTen = hs.HoTen;
            nv.GioiTinh = hs.GioiTinh;
            nv.NgaySinh = hs.NgaySinh;
            nv.CMND = hs.CMND;
            nv.DiaChi = hs.DiaChi;
            nv.SDT = hs.SDT;
            nv.Email = hs.Email;
            nv.TrinhDoHocVan = hs.TrinhDoHocVan;
            nv.TinhTrangSucKhoe = hs.TinhTrangSucKhoe;
            nv.NgoaiNgu = hs.NgoaiNgu;
            nv.NgayVaoLam = DateTime.Now;
            nv.MaQD = id;
            nv.TinhTrang = "Thử việc";
            data.NhanViens.InsertOnSubmit(nv);
            data.SubmitChanges();
            taiKhoan.MaNV = nv.MaNV;
            taiKhoan.MaUV = null;
            data.SubmitChanges();
            data.AcceptHoSo(id2, id);
            data.SubmitChanges();
            var credentials = new NetworkCredential("datnhan2909@gmail.com", "minhdat97");

            // Mail message
            var mail = new MailMessage()
            {
                From = new MailAddress("datnhan2909@gmail.com"),
                Subject = "Tuyển dụng nhân sự công ty Đông Á",
                Body = "Chào " + nv.HoTen + "\n\nHồ sơ ứng tuyển của bạn đã được chấp nhận. \nBạn có thể bắt đầu công việc vào ngày "+ (DateTime.Now.AddDays(1).ToShortDateString()),
            };

            mail.To.Add(new MailAddress(nv.Email));

            // Smtp client
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            // Send it...         
            client.Send(mail);
            return RedirectToAction("DanhSach");
        }
        public ActionResult Decline(int id, int id2)
        {
            data.DeclineHoSo(id2, id);
            data.SubmitChanges();
            return RedirectToAction("DanhSach");
        }
    }
}