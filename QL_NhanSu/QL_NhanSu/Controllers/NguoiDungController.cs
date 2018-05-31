using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using PagedList;
using QL_NhanSu.Models;
using QL_NhanSu.Report;

namespace QL_NhanSu.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult Index()
        {
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            List<string> Gioitinh = new List<string>();
            Gioitinh.Add("Nam");
            Gioitinh.Add("Nữ");
            ViewBag.Gioitinh = Gioitinh;
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, HoSoUngVien uv, TaiKhoan tk)
        {
            var hoten = collection["HoTen"];
            var username = collection["Username"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var gioitinh = collection["Gioitinh"];
            var ngaysinh = String.Format("{0:dd/MM/yyyy}", collection["Ngaysinh"]);
            var cmnd = collection["CMND"];
            var diachi = collection["Diachi"];
            var sdt = collection["SDT"];
            var email = collection["Email"];
            var hocvan = collection["Hocvan"];
            var suckhoe = collection["Suckhoe"];
            var ngoaingu = collection["Ngoaingu"];
            string strRegex = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            Regex re = new Regex(strRegex);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được để trống";
            }
            else if (String.IsNullOrEmpty(username))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }
            else if (matkhaunhaplai != matkhau)
            {
                ViewData["Loi4"] = "Mật khẩu nhập lại không đúng";
            }
            else if (String.IsNullOrEmpty(gioitinh))
            {
                ViewData["Loi5"] = "Giới tính không được để trống";
            }
            else if (String.IsNullOrEmpty(ngaysinh))
            {
                ViewData["Loi6"] = "Ngày sinh không được để trống";
            }
            else if (String.IsNullOrEmpty(cmnd))
            {
                ViewData["Loi7"] = "Phải nhập CMND";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi8"] = "Địa chỉ không được để trống";
            }
            else if (String.IsNullOrEmpty(sdt))
            {
                ViewData["Loi9"] = "Số điện thoại không được để trống";
            }
            else if (re.IsMatch(email) == false)
            {
                ViewData["Loi10"] = "Email nhập không chính xác";
            }
            else if (String.IsNullOrEmpty(hocvan))
            {
                ViewData["Loi11"] = "Trình độ học vấn không được để trống";
            }
            else if (String.IsNullOrEmpty(suckhoe))
            {
                ViewData["Loi12"] = "Tình trạng sức khỏe không được để trống";
            }
            else if (String.IsNullOrEmpty(ngoaingu))
            {
                ViewData["Loi13"] = "Ngoại ngữ không được để trống";
            }
            else
            {
                uv.HoTen = hoten;                
                uv.GioiTinh = gioitinh;
                uv.NgaySinh = DateTime.Parse(ngaysinh);
                uv.CMND = cmnd;
                uv.DiaChi = diachi;
                uv.SDT = sdt;
                uv.Email = email;
                uv.TrinhDoHocVan = hocvan;
                uv.TinhTrangSucKhoe = suckhoe;
                uv.NgoaiNgu = ngoaingu;
                data.HoSoUngViens.InsertOnSubmit(uv);
                data.SubmitChanges();
                tk.Username = username;
                tk.Password = MaHoaMD5.Md5(matkhau.Trim());
                tk.MaUV = uv.MaUV;
                data.TaiKhoans.InsertOnSubmit(tk);
                data.SubmitChanges();
                 

                var credentials = new NetworkCredential("datnhan2909@gmail.com", "minhdat97");

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("datnhan2909@gmail.com"),
                    Subject = "Tuyển dụng nhân sự công ty Đông Á",
                    Body = "Chào " + hoten +"\n\nBạn vừa tạo thành công tài khoản tại trang web công ty Đông Á",
                };

                mail.To.Add(new MailAddress(email));

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

                return RedirectToAction("Dangnhap");
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var username = collection["Username"];
            var matkhau = MaHoaMD5.Md5(collection["Matkhau"].Trim());
            if (String.IsNullOrEmpty(username))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                TaiKhoan tk = data.TaiKhoans.SingleOrDefault(n => n.Username == username && n.Password == matkhau);
                if (tk != null)
                {

                    Session["Taikhoan"] = tk;
                    return RedirectToAction("Index", "NguoiDung");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
            return View();
        }
        public ActionResult NguoidungPartial()
        {
            if (Session["Taikhoan"] != null || Session["Taikhoan"].ToString() != "")
            {
                TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
                ViewBag.Taikhoan = tk.Username;
            }
            return PartialView();
        }
        public ActionResult DangXuat()
        {
            Session["Taikhoan"] = null;
            return RedirectToAction("Index", "NhanSu");
        }
        public ActionResult ChitietNV(int id)
        {
            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nv);
        }
        public ActionResult ChitietUV(int id)
        {
            HoSoUngVien uv = data.HoSoUngViens.SingleOrDefault(n => n.MaUV == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaUV;
            if (uv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(uv);
        }
        [HttpGet]
        public ActionResult SuaNhanVien(int id)
        {
            NhanVien nvien = data.NhanViens.SingleOrDefault(n => n.MaNV == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            if (nvien == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nvien);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaNhanVien(NhanVien nvien, int id, FormCollection f)
        {
            var gioitinh = f["Gioitinh"];
            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            if (ModelState.IsValid)
            {
                nv.HoTen = nvien.HoTen;
                nv.GioiTinh = gioitinh;
                nv.NgaySinh = nvien.NgaySinh;
                nv.CMND = nvien.CMND;
                nv.DiaChi = nvien.DiaChi;
                nv.SDT = nvien.SDT;
                nv.Email = nvien.Email;
                nv.TrinhDoHocVan = nvien.TrinhDoHocVan;
                nv.TinhTrangSucKhoe = nvien.TinhTrangSucKhoe;
                nv.NgoaiNgu = nvien.NgoaiNgu;
                data.SubmitChanges();
                return RedirectToAction("ChitietNV", new { id = nvien.MaNV });
            }
            else
            {
                ModelState.AddModelError(" ", "Sửa thất bại");
            }
            return View();
        }
        public ActionResult CCNhanVien(int id, int? page, string searchStr)
        {
            
            int pageNum = (page ?? 1);
            int pageSize = 30;
            IQueryable<ChiTietCC> chamcong = data.ChiTietCCs.Where(n => n.MaNV == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            if (!string.IsNullOrEmpty(searchStr))
            {
                chamcong = chamcong.Where(n => (n.Ngay + "/" + n.Thang + "/" + n.Nam).Contains(searchStr));
            }
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            ViewBag.searchStr = searchStr;
            return View(chamcong.ToList().ToPagedList(pageNum, pageSize));
        }
        public ActionResult PTNhanVien(int id, int? page)
        {
            int pageNum = (page ?? 1);
            int pageSize = 30;
            List<ChiTietPT> phutroi = data.ChiTietPTs.Where(a => a.MaNV == id).ToList();
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            return View(phutroi.ToList().ToPagedList(pageNum, pageSize));
        }
        public ActionResult KTKLNhanVien(int id, int? page)
        {
            int pageNum = (page ?? 1);
            int pageSize = 5;
            List<KT_KL> ktkl = data.KT_KLs.Where(a => a.MaNV == id).ToList();
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            return View(ktkl.ToList().ToPagedList(pageNum, pageSize));
        }
        public ActionResult LuongNhanVien(int id, int? page/*, int thang, int nam*/)
        {
            int pageNum = (page ?? 1);
            int pageSize = 5;
            IQueryable<Luong> luong = data.Luongs.Where(a => a.MaNV == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;

            return View(luong.ToList().ToPagedList(pageNum, pageSize));
            
        }
        public ActionResult ChitietLuong(int id)
        {
            Luong lg = data.Luongs.SingleOrDefault(n => n.MaLuong == id);
            
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            if (lg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(lg);
        }
        public ActionResult XuatBangLuong(int id)
        {
            Luong lg = data.Luongs.SingleOrDefault(n => n.MaLuong == id);
            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == lg.MaNV);
            QuyetDinhTD qd = data.QuyetDinhTDs.SingleOrDefault(n => n.MaQD == nv.MaQD);
            ChucVu cv = data.ChucVus.SingleOrDefault(n => n.MaCV == qd.MaCV);
            decimal mucLuong = 0;
            decimal giatringaycong = 0;
            decimal giatritresom = 0;
            decimal giatringaynghicop = 0;
            decimal giatringaynghikp = 0;
            decimal giatriphutroi = 0;
            if (nv.TinhTrang == "Thử việc")
            {
                mucLuong = cv.MucLuongThuViec;
                giatringaycong = Convert.ToDecimal(mucLuong * lg.Songaycong);
                giatritresom = Convert.ToDecimal(mucLuong * lg.Solantresom);
                giatringaynghicop = Convert.ToDecimal(mucLuong * lg.Songaynghicop);
                giatringaynghikp = Convert.ToDecimal(mucLuong * lg.Songaynghikp);
                giatriphutroi = Convert.ToDecimal(mucLuong * lg.Sogiopt);
            }
            else
            {
                mucLuong = cv.MucLuongCT;
                giatringaycong = Convert.ToDecimal(mucLuong * lg.Songaycong);
                giatritresom = Convert.ToDecimal(mucLuong * lg.Solantresom);
                giatringaynghicop = Convert.ToDecimal(mucLuong * lg.Songaynghicop);
                giatringaynghikp = Convert.ToDecimal(mucLuong * lg.Songaynghikp);
                giatriphutroi = Convert.ToDecimal(mucLuong * lg.Sogiopt);
            }
            LuongNV db = new LuongNV();
            db.DataTable1.AddDataTable1Row(lg.MaLuong, lg.MaNV, nv.HoTen, lg.Thang, lg.Nam, Convert.ToInt32(lg.Songaycong), Convert.ToInt32(lg.Solantresom), Convert.ToInt32(lg.Songaynghicop), Convert.ToInt32(lg.Songaynghikp), Convert.ToDecimal(lg.Khenthuong), Convert.ToDecimal(lg.Kyluat), lg.GiaTri, mucLuong, Convert.ToInt32(lg.Sogiopt), giatringaycong, giatritresom, giatringaynghicop, giatringaynghikp, giatriphutroi);

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/BangLuong.rpt")));
            rd.SetDataSource(db);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Bangluong.pdf");
        }

        public ActionResult DanhSachQD(int id, int? page)
        {
            int pageNum = (page ?? 1);
            int pageSize = 5;
            List<DanhSachUV> ds = data.DanhSachUVs.Where(a => a.MaUV == id).ToList();
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaUV;
            return View(ds.ToList().ToPagedList(pageNum, pageSize));
        }
        public ActionResult ChitietQD (int id, int id2)
        {
            DanhSachUV qd = data.DanhSachUVs.SingleOrDefault(n => n.MaQD == id && n.MaUV == id2);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaUV;
            if (qd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(qd);
        }
        [HttpGet]
        public ActionResult XoaHoSo(int id, int id2)
        {
            DanhSachUV qd = data.DanhSachUVs.SingleOrDefault(n => n.MaQD == id && n.MaUV == id2);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaUV;
            if (qd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(qd);
        }
        [HttpPost, ActionName("XoaHoSo")]
        public ActionResult Xacnhanxoa(int id, int id2)
        {
            DanhSachUV qd = data.DanhSachUVs.SingleOrDefault(n => n.MaQD == id && n.MaUV == id2);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaUV;
            if (qd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.DanhSachUVs.DeleteOnSubmit(qd);
            data.SubmitChanges();
            return RedirectToAction("DanhSachQD", new { id = id2});
        }
        [HttpGet]
        public ActionResult SuaUngVien(int id)
        {
            HoSoUngVien uvien = data.HoSoUngViens.SingleOrDefault(n => n.MaUV == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaUV;
            if (uvien == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(uvien);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaUngVien(HoSoUngVien uvien, int id, FormCollection f)
        {
            var gioitinh = f["Gioitinh"];
            HoSoUngVien uv = data.HoSoUngViens.SingleOrDefault(n => n.MaUV == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaUV;
            if (ModelState.IsValid)
            {
                uv.HoTen = uvien.HoTen;
                uv.GioiTinh = gioitinh;
                uv.NgaySinh = uvien.NgaySinh;
                uv.CMND = uvien.CMND;
                uv.DiaChi = uvien.DiaChi;
                uv.SDT = uvien.SDT;
                uv.Email = uvien.Email;
                uv.TrinhDoHocVan = uvien.TrinhDoHocVan;
                uv.TinhTrangSucKhoe = uvien.TinhTrangSucKhoe;
                uv.NgoaiNgu = uvien.NgoaiNgu;
                data.SubmitChanges();
                return RedirectToAction("ChitietUV", new { id = uvien.MaUV });
            }
            else
            {
                ModelState.AddModelError(" ", "Sửa thất bại");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DoiMatKhau(string id)
        {
            TaiKhoan tkhoan = data.TaiKhoans.SingleOrDefault(n => n.Username == id);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaNV;
            if (tkhoan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tkhoan);
        }
        [HttpPost]
        public ActionResult DoiMatKhau(TaiKhoan tkhoan, string id, FormCollection collection)
        {
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaUV = tk.MaUV;
            ViewBag.MaNV = tk.MaNV;
            var mkcu = collection["matkhaucu"];
            var mkmoi = collection["matkhaumoi"];
            var mknhaplai = collection["matkhaunhaplai"];

            if (String.IsNullOrEmpty(mkcu))
            {
                ViewData["Loi1"] = "Phải nhập mật khẩu cũ";
            }
            else if (String.IsNullOrEmpty(mkmoi))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu mới";
            }
            else if (mknhaplai != mkmoi)
            {
                ViewData["Loi3"] = "Mật khẩu nhập lại không khớp";
            }
            else
            {
                TaiKhoan taik = data.TaiKhoans.ToList().Find(n => n.Username == id);
                if (MaHoaMD5.Md5(mkcu) == tk.Password)
                {
                    taik.Password = MaHoaMD5.Md5(mkmoi);
                    data.SubmitChanges();
                    ViewBag.ThongBao = "Đổi mật khẩu thành công";
                }
                else
                {
                    ViewBag.ThongBao = "Mật khẩu cũ không đúng";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult NhanLuong(int id, int thang, int nam)
        {
            Luong luong = data.Luongs.SingleOrDefault(a => a.MaNV == id && a.Thang == thang && a.Nam == nam);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            if (luong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(luong);
        }
        [HttpPost, ActionName("NhanLuong")]
        public ActionResult Xacnhannhan(int id, int thang, int nam)
        {
            Luong luong = data.Luongs.SingleOrDefault(a => a.MaNV == id && a.Thang == thang && a.Nam == nam);
            TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
            ViewBag.Taikhoan = tk.Username;
            ViewBag.MaNV = tk.MaNV;
            if (luong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            luong.TinhTrang = "Đã nhận";
            data.SubmitChanges();
            return RedirectToAction("LuongNhanVien", new { id = tk.MaNV });
        }
    }
}