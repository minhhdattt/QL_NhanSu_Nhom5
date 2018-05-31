using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QL_NhanSu.Models;

namespace QL_NhanSu.Controllers
{
    public class LuongController : Controller
    {
        // GET: Luong
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult Luong(string NV, string Year, string Month)
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 2 || tk.Allower == 4)
            {                
                
                IQueryable<Luong> luong = data.Luongs;               
                ViewBag.Thang = Month;
                ViewBag.Nam = Year;
                ViewBag.MaNV = NV;
                if (DateTime.Now.Day <= 5)
                {
                    if (!String.IsNullOrEmpty(Month) && !String.IsNullOrEmpty(Year))
                    {
                        int thang = Convert.ToInt32(Month);
                        int nam = Convert.ToInt32(Year);
                        BangCC cc = data.BangCCs.SingleOrDefault(n => n.Thang == thang && n.Nam == nam);
                        if (cc != null)
                        {
                            if (String.IsNullOrEmpty(NV))
                            {
                                List<NhanVien> lstNV = data.NhanViens.ToList();
                                foreach (var item in lstNV)
                                {
                                    Luong lstLuong = data.Luongs.ToList().Find(n => n.Thang == thang && n.Nam == nam && n.MaNV == item.MaNV);
                                    if (lstLuong == null)
                                    {
                                        data.TinhLuong(item.MaNV, thang, nam);
                                        data.SubmitChanges();
                                    }
                                    else
                                    {
                                        data.CapNhatLuong(item.MaNV, thang, nam);
                                        data.SubmitChanges();
                                    }
                                }
                                luong = luong.Where(n => n.Thang == thang && n.Nam == nam);
                            }
                            else
                            {
                                int manv = Convert.ToInt32(NV);
                                Luong lstLuong = data.Luongs.ToList().Find(n => n.Thang == thang && n.Nam == nam && n.MaNV == manv);
                                if (lstLuong == null)
                                {
                                    data.TinhLuong(manv, thang, nam);
                                    data.SubmitChanges();
                                }
                                else
                                {
                                    data.CapNhatLuong(manv, thang, nam);
                                    data.SubmitChanges();
                                }
                                luong = luong.Where(n => n.Thang == thang && n.Nam == nam && n.MaNV == manv);
                            }
                            
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(Month) && !String.IsNullOrEmpty(Year) && !String.IsNullOrEmpty(NV))
                    {
                        int thang = Convert.ToInt32(Month);
                        int nam = Convert.ToInt32(Year);
                        int manv = Convert.ToInt32(NV);
                        ChiTietCC chitiet = data.ChiTietCCs.ToList().Find(n => n.Thang == thang && n.Nam == nam && n.MaNV == manv);
                        if (chitiet != null)
                        {
                            Luong lstLuong = data.Luongs.ToList().Find(n => n.Thang == thang && n.Nam == nam && n.MaNV == manv);
                            if (lstLuong == null)
                            {
                                data.TinhLuong(manv, thang, nam);
                                data.SubmitChanges();
                            }
                            else
                            {
                                data.CapNhatLuong(manv, thang, nam);
                                data.SubmitChanges();
                            }
                            luong = luong.Where(n => n.Thang == thang && n.Nam == nam && n.MaNV == manv);
                        }
                    }
                }
                return View(luong.ToList().OrderBy(n => n.MaNV));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
            
        }
        public ActionResult ChitietLuong(int id)
        {
            Luong lg = data.Luongs.SingleOrDefault(n => n.MaLuong == id);
            if (lg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(lg);
        }
        [HttpGet]
        public ActionResult XoaLuong(int id)
        {
            Luong lg = data.Luongs.SingleOrDefault(n => n.MaLuong == id);
            if (lg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(lg);
        }
        [HttpPost, ActionName("XoaLuong")]
        public ActionResult Xacnhanxoa(int id)
        {
            Luong lg = data.Luongs.SingleOrDefault(n => n.MaLuong == id);
            KT_KL ktkl = data.KT_KLs.ToList().Find(n => n.MaNV == lg.MaNV && n.Ngay.Month == lg.Thang && n.Ngay.Year == lg.Nam);
            if (lg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ktkl.TrangThai = "Đang xử lý";
            data.SubmitChanges();
            data.Luongs.DeleteOnSubmit(lg);
            data.SubmitChanges();
            return RedirectToAction("Luong");
        }
    }
}