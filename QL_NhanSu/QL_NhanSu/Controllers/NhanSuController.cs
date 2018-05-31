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
    public class NhanSuController : Controller
    {
        // GET: NhanSu
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        private List<QuyetDinhTD> LayQDmoi(int count)
        {
            List<DanhSachUV> ds = data.DanhSachUVs.ToList();
            return data.QuyetDinhTDs.Where(a => a.SoLuong != 0).OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 7;
            int pageNum = (page ?? 1);
            var qdmoi = LayQDmoi(10);
            return View(qdmoi.ToPagedList(pageNum, pageSize));

        }

        public ActionResult PhongBan()
        {
            var phongban = from pb in data.PhongBans select pb;
            return PartialView(phongban);
        }
        public ActionResult ChucVu()
        {
            var chucvu = from cv in data.ChucVus select cv;
            return PartialView(chucvu);
        }

        

        public ActionResult TDtheophongban(string id)
        {
            var tuyendung = from td in data.QuyetDinhTDs where td.MaPB==id select td;
            return View(tuyendung);
        }
        public ActionResult TDtheochucvu(int id)
        {
            var tuyendung = from td in data.QuyetDinhTDs where td.MaCV == id select td;
            return View(tuyendung);
        }
        public ActionResult Details(int id)
        {
            var tuyendung = from td in data.QuyetDinhTDs
                            where td.MaQD == id
                            select td;
            return View(tuyendung.Single());
        }

        public ActionResult NopHoSo(int id, DanhSachUV ds)
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            else
            {
                TaiKhoan tk = (TaiKhoan)Session["Taikhoan"];
                
                int mauv = Convert.ToInt16(tk.MaUV);
                DanhSachUV dsuv = data.DanhSachUVs.ToList().Find(n => n.MaQD == id && n.MaUV == mauv);
                if (mauv != 0)
                {
                    if (dsuv==null)
                    {
                        data.ThemHoSo(mauv, id, DateTime.Now);
                        data.SubmitChanges();
                        return RedirectToAction("Xacnhanhoso", "NhanSu");
                    }
                    else
                    {
                        return RedirectToAction("ThongBao", "NhanSu");
                    }
                }
                else
                {
                    return RedirectToAction("ThongBao", "NhanSu");
                }
            }            
        }
        public ActionResult Xacnhanhoso()
        {
            return View();
        }
        public ActionResult ThongBao()
        {
            return View();
        }
        public ActionResult Search(string searchStr, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<QuyetDinhTD> qd = data.QuyetDinhTDs;
            if (!string.IsNullOrEmpty(searchStr))
            {
                qd = qd.Where(n => n.PhongBan.TenPhongBan.Contains(searchStr) || n.ChucVu.TenChucVu.Contains(searchStr) || n.Mota.Contains(searchStr) /*|| n.Ngaycapnhat.Equals(Convert.ToDateTime(searchStr)) */|| n.TrangThai.Contains(searchStr));
            }
            ViewBag.searchStr = searchStr;
            return View(qd.ToList().OrderByDescending(n => n.Ngaycapnhat).ToPagedList(pageNumber,pageSize));
        }
    }
}