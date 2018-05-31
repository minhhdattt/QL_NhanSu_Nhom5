using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_NhanSu.Models;

namespace QL_NhanSu.Controllers
{
    public class PhuTroiController : Controller
    {
        // GET: PhuTroi
        dbQLNhanSuDataContext data = new dbQLNhanSuDataContext();
        public ActionResult PhuTroi(string Ngaycham, string manv)
        {
            QuanLy tk = (QuanLy)Session["Taikhoanadmin"];
            if (tk.Allower == 2 || tk.Allower == 4)
            {
                IQueryable<ChiTietPT> phutroi = data.ChiTietPTs;
                ViewBag.Ngaycham = Ngaycham;
                ViewBag.MaNV = manv;
                if (!string.IsNullOrEmpty(Ngaycham) && !string.IsNullOrWhiteSpace(manv))
                {
                    //DateTime ngay = Convert.ToDateTime(Ngaycham);
                    int maNV = Convert.ToInt16(manv);
                    DateTime ngaycham = Convert.ToDateTime(Ngaycham);
                    DateTime now = DateTime.Now;
                    if (DateTime.Compare(ngaycham, now) <= 0)
                    {
                        BangPT bptroi = data.BangPTs.SingleOrDefault(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year));
                        if (bptroi == null)
                        {
                            BangPT bpt = new BangPT();
                            bpt.Thang = Convert.ToInt16(ngaycham.Month);
                            bpt.Nam = Convert.ToInt16(ngaycham.Year);
                            data.BangPTs.InsertOnSubmit(bpt);
                            data.SubmitChanges();
                            NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == maNV);
                            if (nv != null)
                            {
                                if (DateTime.Compare(nv.NgayVaoLam, ngaycham) < 0)
                                {
                                    ChiTietPT pt = new ChiTietPT();
                                    pt.Thang = bpt.Thang;
                                    pt.Nam = bpt.Nam;
                                    pt.Ngay = Convert.ToInt16(ngaycham.Day);
                                    pt.MaNV = nv.MaNV;
                                    data.ChiTietPTs.InsertOnSubmit(pt);
                                }
                                data.SubmitChanges();
                            }
                            phutroi = phutroi.Where(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year) && n.Ngay == Convert.ToInt16(ngaycham.Day) && n.MaNV == maNV);
                        }
                        else if (bptroi != null)
                        {
                            ChiTietPT chiTietPT = data.ChiTietPTs.ToList().Find(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year) && n.Ngay == Convert.ToInt16(ngaycham.Day) && n.MaNV == maNV);
                            if (chiTietPT == null)
                            {

                                NhanVien nv = data.NhanViens.SingleOrDefault(n => n.MaNV == maNV);
                                if (nv != null)
                                {
                                    if (DateTime.Compare(nv.NgayVaoLam, ngaycham) < 0)
                                    {
                                        ChiTietPT pt = new ChiTietPT();
                                        pt.Thang = bptroi.Thang;
                                        pt.Nam = bptroi.Nam;
                                        pt.Ngay = Convert.ToInt16(ngaycham.Day);
                                        pt.MaNV = nv.MaNV;
                                        data.ChiTietPTs.InsertOnSubmit(pt);

                                    }
                                    data.SubmitChanges();
                                }
                                phutroi = phutroi.Where(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year) && n.Ngay == Convert.ToInt16(ngaycham.Day) && n.MaNV == maNV);
                            }
                            else
                            {
                                phutroi = phutroi.Where(n => n.Thang == Convert.ToInt16(ngaycham.Month) && n.Nam == Convert.ToInt16(ngaycham.Year) && n.Ngay == Convert.ToInt16(ngaycham.Day) && n.MaNV == maNV);
                            }
                        }
                    }
                    
                }               
                return View(phutroi.ToList().OrderByDescending(n => DateTime.Parse(n.Ngay + "/" + n.Thang + "/" + n.Nam)));
            }
            else
            {
                return RedirectToAction("ThongBao", "Admin");
            }
        }
        public ActionResult Capnhatphutroi(int id, int ngay, int thang, int nam, FormCollection f, string ncham, string search, string nv)
        {
            ChiTietPT chiTietPT = data.ChiTietPTs.SingleOrDefault(n => n.Thang == thang && n.Nam == nam && n.Ngay == ngay && n.MaNV == id);
            if (chiTietPT != null)
            {
                chiTietPT.GioPT = Convert.ToInt16(f["txtSogio"]);
                data.SubmitChanges();
            }
            return RedirectToAction("PhuTroi", new { Ngaycham = ngay + "/" + thang + "/" + nam, mauv = nv , searchStr = search });
        }
    }
}