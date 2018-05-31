using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;
using PagedList;
using PagedList.Mvc;

namespace QL_NhanSu.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var mk = MaHoaMD5.Md5(collection["password"].Trim());
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập username";
            }
            else if (String.IsNullOrEmpty(mk))
            {
                ViewData["Loi2]"] = "Phải nhập password";
            }
            else
            {
                QuanLy ad = data.QuanLies.SingleOrDefault(n => n.Username == tendn && n.Password == mk);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult AdminPartial()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                RedirectToAction("Login", "Admin");                
            }
            else
            {
                QuanLy ad = (QuanLy)Session["Taikhoanadmin"];
                ViewBag.Admin = ad.Username;
            }
            return PartialView();
        }
        public ActionResult Logout()
        {
            Session["Taikhoanadmin"] = null;
            return RedirectToAction("Index", "NhanSu");
        }
        public ActionResult QuanLy(int? page, string searchStr)
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 4)
            {
                IQueryable<QuanLy> ql = data.QuanLies;
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                if (!string.IsNullOrEmpty(searchStr))
                {
                    ql = ql.Where(n => n.Username.Contains(searchStr) || n.Fullname.Contains(searchStr) || n.Email.Contains(searchStr) || n.SDT.Contains(searchStr));
                }
                ViewBag.searchStr = searchStr;
                return View(ql.ToList().OrderBy(n => n.Username).ToPagedList(pageNumber, pageSize));
            }
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }
        [HttpGet]
        public ActionResult ThemTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemTaiKhoan(QuanLy ql, FormCollection collection)
        {
            var mk = collection["Matkhau"];
            var mknhaplai = collection["Matkhaunhaplai"];
            var loai = collection["Loai"];
            if(String.IsNullOrEmpty(mk))
            {
                ViewData["Loi"] = "Phải nhập mật khẩu";
            }
            else if (mknhaplai != mk)
            {
                ViewData["Loi1"] = "Mật khẩu nhập lại không đúng";
            }
            else if (ModelState.IsValid)
            {
                ql.Password = MaHoaMD5.Md5(mk);
                ql.Allower = Convert.ToInt32(loai);
                data.QuanLies.InsertOnSubmit(ql);
                data.SubmitChanges();
                return RedirectToAction("QuanLy");

            }
            else
            {
                ModelState.AddModelError(" ", "Thêm thất bại");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SuaTaiKhoan(string id)
        {
            QuanLy ql = data.QuanLies.SingleOrDefault(n => n.Username == id);
            ViewBag.Username = ql.Username;
            if (ql == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ql);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaTaiKhoan(QuanLy ql, string id)
        {
            QuanLy tk = data.QuanLies.ToList().Find(n => n.Username == id);
            if (ModelState.IsValid)
            {
                tk.Fullname = ql.Fullname;
                tk.Email = ql.Email;
                tk.SDT = ql.SDT;
                data.SubmitChanges();
                return RedirectToAction("ChitietTaiKhoan", new { id = tk.Username });
            }
            else
            {
                ModelState.AddModelError(" ", "Sửa thất bại");
            }
            return View();

        }
        public ActionResult ChitietTaiKhoan(string id)
        {
            QuanLy ql = data.QuanLies.SingleOrDefault(n => n.Username == id);
            if (ql == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ql);
        }
        [HttpGet]
        public ActionResult XoaTaiKhoan(string id)
        {
            QuanLy ql = data.QuanLies.SingleOrDefault(n => n.Username == id);
            if (ql == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ql);
        }
        [HttpPost, ActionName("XoaTaiKhoan")]
        public ActionResult Xacnhanxoa(string id)
        {
            QuanLy ql = data.QuanLies.SingleOrDefault(n => n.Username == id);
            if (ql == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.QuanLies.DeleteOnSubmit(ql);
            data.SubmitChanges();
            return RedirectToAction("QuanLy");
        }
        [HttpGet]
        public ActionResult Capnhat(string id)
        {
            QuanLy ql = data.QuanLies.SingleOrDefault(n => n.Username == id);
            ViewBag.Username = ql.Username;
            if (ql == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ql);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Capnhat(QuanLy ql, string id, FormCollection collection)
        {
            var loai = collection["Loai"];
            QuanLy tk = data.QuanLies.ToList().Find(n => n.Username == id);
            if (ModelState.IsValid)
            {
                    tk.IsAdmin = ql.IsAdmin;
                    tk.Allower = Convert.ToInt32(loai);
                    data.SubmitChanges();
                    return RedirectToAction("QuanLy");
            }
            else
            {
                ModelState.AddModelError(" ", "Cập nhật thất bại");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DoiMatKhau(string id)
        {
            QuanLy ql = data.QuanLies.SingleOrDefault(n => n.Username == id);
            ViewBag.Username = ql.Username;
            if (ql == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ql);
        }
        [HttpPost]
        public ActionResult DoiMatKhau(QuanLy ql, string id, FormCollection collection)
        {
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
                QuanLy tk = data.QuanLies.ToList().Find(n => n.Username == id);
                if(MaHoaMD5.Md5(mkcu) == tk.Password)
                {
                    tk.Password = MaHoaMD5.Md5(mkmoi);
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
        public ActionResult ThongBao()
        {
            return View();
        }
    }
}