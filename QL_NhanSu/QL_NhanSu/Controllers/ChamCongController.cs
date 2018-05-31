using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;


namespace QL_NhanSu.Controllers
{
    public class ChamCongController : Controller
    {
        // GET: ChamCong
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        //public List<ChamCong> getChamCong(int iMaNV)
        //{
        //    List<ChamCong> lstChamCong = new List<ChamCong>();
        //    ChamCong chamcong = lstChamCong.Find(n => n.iMaNV == iMaNV)
        //    if (chamcong == null)
        //    {
        //        chamcong = new ChamCong(iMaNV);
        //    }
        //}
        public ActionResult ChamCong(string Ngaycham)
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 2 || tk.Allower == 4)
            {
                IQueryable<ChiTietCC> chamcong = data.ChiTietCCs;
                ViewBag.Ngaycham = Ngaycham;
                if (!string.IsNullOrEmpty(Ngaycham))
                {
                    DateTime ngaycham = Convert.ToDateTime(Ngaycham);
                    DateTime now = DateTime.Now;
                    if(DateTime.Compare(ngaycham,now) <= 0)
                    {
                        BangCC bccong = data.BangCCs.SingleOrDefault(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year));
                        if (bccong == null)
                        {
                            BangCC bcc = new BangCC();
                            List<NhanVien> lstNV = data.NhanViens.ToList();
                            bcc.Thang = Convert.ToInt16(ngaycham.Month);
                            bcc.Nam = Convert.ToInt16(ngaycham.Year);
                            data.BangCCs.InsertOnSubmit(bcc);
                            data.SubmitChanges();
                            foreach (var item in lstNV)
                            {
                                if (DateTime.Compare(item.NgayVaoLam, ngaycham) < 0)
                                {
                                    ChiTietCC cc = new ChiTietCC();
                                    cc.Thang = bcc.Thang;
                                    cc.Nam = bcc.Nam;
                                    cc.Ngay = Convert.ToInt16(ngaycham.Day);
                                    cc.MaNV = item.MaNV;
                                    data.ChiTietCCs.InsertOnSubmit(cc);

                                }
                            }
                            data.SubmitChanges();
                            chamcong = chamcong.Where(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year) && n.Ngay == Convert.ToInt16(ngaycham.Day));
                        }
                        else if (bccong != null)
                        {
                            ChiTietCC chiTietCC = data.ChiTietCCs.ToList().Find(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year) && n.Ngay == Convert.ToInt16(ngaycham.Day));
                            if (chiTietCC == null)
                            {
                                List<NhanVien> lstNV = data.NhanViens.ToList();
                                foreach (var item in lstNV)
                                {
                                    if (DateTime.Compare(item.NgayVaoLam, ngaycham) < 0)
                                    {
                                        ChiTietCC cc = new ChiTietCC();
                                        cc.Thang = bccong.Thang;
                                        cc.Nam = bccong.Nam;
                                        cc.Ngay = Convert.ToInt16(ngaycham.Day);
                                        cc.MaNV = item.MaNV;
                                        data.ChiTietCCs.InsertOnSubmit(cc);

                                    }
                                }
                                data.SubmitChanges();
                                chamcong = chamcong.Where(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year) && n.Ngay == Convert.ToInt16(ngaycham.Day));
                            }
                            else
                            {
                                chamcong = chamcong.Where(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year) && n.Ngay == Convert.ToInt16(ngaycham.Day));
                            }
                        }
                    }                   
                }
                return View(chamcong.ToList().OrderByDescending(n => DateTime.Parse(n.Ngay + "/" + n.Thang + "/" + n.Nam)));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }
        
        public ActionResult Capnhatchamcong(int id, int ngay, int thang, int nam, FormCollection f, string ncham)
        {
            List<ChiTietCC> lstCTCC = data.ChiTietCCs.ToList();
            ChiTietCC chiTietCC = lstCTCC.SingleOrDefault(n => n.Thang == thang && n.Nam == nam && n.Ngay == ngay && n.MaNV == id);
            if (chiTietCC != null)
            {
                chiTietCC.TrangThai = f["txtTrangThai"].ToString();
                data.SubmitChanges();
            }

            return RedirectToAction("ChamCong", new { /*Ngaycham = ngay + "/" + thang + "/" + nam*/ Ngaycham = ncham});
        }
    }
}