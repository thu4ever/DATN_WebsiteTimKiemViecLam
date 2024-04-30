using DATN_WebsiteTimKiemViecLam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Linq;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using System.Text;
using static NuGet.Packaging.PackagingConstants;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;

namespace DATN_WebsiteTimKiemViecLam.Controllers
{
    public class UngVienController : Controller
    {
        private readonly db_WebsiteTimkiemvieclamContext _context;
        public UngVienController(db_WebsiteTimkiemvieclamContext context)
        {
            _context = context;
        }
        public IActionResult btnHienthidanhsachVL(int? page)
        {
            int pageSize = 9; // Số lượng mục trên mỗi trang
            int pageNumber = (page ?? 1);

            var danhSachBaiTuyenDung = _context.TblBaituyendungs
              .Include(baiTuyenDung => baiTuyenDung.FkSMaDnNavigation) // Nạp dữ liệu từ bảng TblDoanhnghiep
              .Where(p=>p.ITrangthai==1)
              .Select(baiTuyenDung => new vDanhsachvieclam
              {
                  PkSMaBai = baiTuyenDung.PkSMaBai,
                  STenBai = baiTuyenDung.STenBai,
                  SLogo = baiTuyenDung.FkSMaDnNavigation.SLogo,
                  sTendoanhnghiep = baiTuyenDung.FkSMaDnNavigation.STenDn,
                  sDiachi = baiTuyenDung.SDiachicuthe,
                  FMucLuong = baiTuyenDung.FMucLuongtoithieu,
                  FMucLuongTD = baiTuyenDung.FMucluongtoida,
                  FkSMaDn = baiTuyenDung.FkSMaDn,
                  ITrangthai = baiTuyenDung.ITrangthai
              })
              .ToList();
            ViewBag.TotalPages = Math.Ceiling((double)danhSachBaiTuyenDung.Count / pageSize);
            ViewBag.CurrentPage = pageNumber;
            List<TblDoanhnghiep> model1Data = _context.TblDoanhnghieps.ToList();
            ViewBag.model1Data = model1Data;
            return View("vDanhsachvieclam", danhSachBaiTuyenDung.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult btnHienthidanhsachDN()
        {
            List<TblDoanhnghiep> model1Data = _context.TblDoanhnghieps.ToList();
            ViewBag.model1Data = model1Data;
            return View("vDanhsachdoanhnghiep", model1Data);
        }
        public IActionResult btnHienthichitietvieclam(long PkSMaBai)
        {
            vChitietvieclam result = _context.TblBaituyendungs
             .Include(baiTuyenDung => baiTuyenDung.FkSMaDnNavigation)
             .Where(p => p.PkSMaBai == PkSMaBai)
             .Select(baiTuyenDung => new vChitietvieclam
             {
                 PkSMaBai = baiTuyenDung.PkSMaBai,
                 STenBai = baiTuyenDung.STenBai,
                 SLogo = baiTuyenDung.FkSMaDnNavigation.SLogo,
                 STenDn = baiTuyenDung.FkSMaDnNavigation.STenDn,
                 SDiachicuthe = baiTuyenDung.SDiachicuthe,
                 FMucLuongtoithieu = baiTuyenDung.FMucLuongtoithieu,
                 SYeuCau = baiTuyenDung.SYeuCau,
                 SQuyenLoi = baiTuyenDung.SQuyenLoi,
                 SMota = baiTuyenDung.FkSMaDnNavigation.SMota,
                 ISoLuong = baiTuyenDung.ISoLuong,
                 ITrangthai = baiTuyenDung.ITrangthai,
                 DTgTuyenDung = baiTuyenDung.DTgTuyenDung,
                 FkSMaDn = baiTuyenDung.FkSMaDn,
                 FNamKinhNghiem = baiTuyenDung.FNamKinhNghiem,
                 FMucluongtoida = baiTuyenDung.FMucluongtoida,
                 DTgDangBai = baiTuyenDung.DTgDangBai
             })
             .FirstOrDefault();
            return View("vChitietvieclam", result);
        }
        public IActionResult btnHienthichitietDN(long FkSMaDn)
        {
            TblDoanhnghiep tblDoanhnghiep = _context.TblDoanhnghieps.Where(p => p.PkSMaDn == FkSMaDn).FirstOrDefault();
            var danhSachBaiTuyenDung = _context.TblBaituyendungs
               .Include(baiTuyenDung => baiTuyenDung.FkSMaDnNavigation)
               .Where(p => p.FkSMaDn == FkSMaDn)
               .Select(baiTuyenDung => new vDanhsachvieclam
               {
                   PkSMaBai = baiTuyenDung.PkSMaBai,
                   STenBai = baiTuyenDung.STenBai,
                   SLogo = baiTuyenDung.FkSMaDnNavigation.SLogo,
                   sTendoanhnghiep = baiTuyenDung.FkSMaDnNavigation.STenDn,
                   sDiachi = baiTuyenDung.SDiachicuthe,
                   FMucLuong = baiTuyenDung.FMucLuongtoithieu
               })
               .ToList();
            ViewBag.tblBaituyendung = danhSachBaiTuyenDung;
            return View("vChitietdoanhnghiep", tblDoanhnghiep);
        }
        public bool CheckValidTimkiemVieclam(String dThoigiandangtuyen, String txtkinhnghiem, String txtDiachi, String txtMucluong, String txtTencongviec)
        {
            if(dThoigiandangtuyen == null && txtkinhnghiem == null && txtDiachi == null && txtMucluong == null && txtTencongviec == null)
                return false;
            if(dThoigiandangtuyen==null)
                return false;
            if(txtkinhnghiem==null)
                return false;
            if( txtDiachi==null)
                return false;
            if(txtMucluong==null)
                return false;
            if(txtTencongviec==null)
                return false;
            return true;
        }
        public IActionResult btnTimkiemViecLam()
        {
            return View("vDanhsachtatcavieclam");
        }

        //Kiem tr unit cho Button Tim Kiem
        public int btn_TimkiemViecLam(String dThoigiandangtuyen, String txtkinhnghiem, String txtDiachi, String txtMucluong, String txtTencongviec)
        {
            if (CheckValidTimkiemVieclam(dThoigiandangtuyen, txtkinhnghiem, txtDiachi, txtMucluong, txtTencongviec))
                return 0;
            DateTime now = DateTime.Now;

            TimeSpan time = TimeSpan.FromDays(int.Parse(dThoigiandangtuyen));
            var query = _context.TblBaituyendungs
           .Where(u => u.STenBai.Contains(txtTencongviec))
           .Where(u => u.SDiachicuthe.Contains(txtDiachi))
           .Where(u => u.FNamKinhNghiem < float.Parse(txtkinhnghiem))
           .ToList(); // Chuyển kết quả của truy vấn thành danh sách

            var result = query.AsEnumerable() // Chuyển sang việc thực hiện trên máy khách
                .Where(u => u.FMucluongtoida > float.Parse(txtMucluong))
                .Where(u => now - u.DTgDangBai < TimeSpan.FromDays(int.Parse(dThoigiandangtuyen)))
                .Join(_context.TblDoanhnghieps,
                      baiTuyenDung => baiTuyenDung.FkSMaDn,
                      doanhNghiep => doanhNghiep.PkSMaDn,
                      (baiTuyenDung, doanhNghiep) => new vDanhsachvieclam
                      {
                          STenBai = baiTuyenDung.STenBai,
                          SLogo = doanhNghiep.SLogo,
                          sTendoanhnghiep = doanhNghiep.STenDn,
                          sDiachi = baiTuyenDung.SDiachicuthe,
                          FMucLuong = baiTuyenDung.FMucLuongtoithieu,
                          FMucLuongTD = baiTuyenDung.FMucluongtoida
                      }).ToList();
            if (result.Count > 0)
                return 1;
            return 0;
        }

        [HttpPost]
        public IActionResult btnTimkiemViecLam(int? page, String dThoigiandangtuyen, String txtkinhnghiem, String txtDiachi, String txtMucluong, String txtTencongviec)
        {
            if (txtTencongviec == null)
            {
                txtTencongviec = " ";
            }
            if (txtDiachi == null)
            {
                txtDiachi = " ";
            }
            if (txtkinhnghiem == null)
            {
                txtkinhnghiem = "100";
            }
            DateTime now = DateTime.Now;
            int pageSize = 8; // Số lượng mục trên mỗi trang
            int pageNumber = (page ?? 1);
            TimeSpan time = TimeSpan.FromDays(int.Parse(dThoigiandangtuyen));
            var query = _context.TblBaituyendungs
           .Where(u => u.STenBai.Contains(txtTencongviec))
           .Where(u => u.SDiachicuthe.Contains(txtDiachi))
           .Where(u => u.FNamKinhNghiem < float.Parse(txtkinhnghiem))
           .ToList(); // Chuyển kết quả của truy vấn thành danh sách

            var result = query.AsEnumerable() // Chuyển sang việc thực hiện trên máy khách
                .Where(u => u.FMucluongtoida > float.Parse(txtMucluong))
                .Where(u => now - u.DTgDangBai < TimeSpan.FromDays(int.Parse(dThoigiandangtuyen)))
                .Join(_context.TblDoanhnghieps,
                      baiTuyenDung => baiTuyenDung.FkSMaDn,
                      doanhNghiep => doanhNghiep.PkSMaDn,
                      (baiTuyenDung, doanhNghiep) => new vDanhsachvieclam
                      {
                          STenBai = baiTuyenDung.STenBai,
                          SLogo = doanhNghiep.SLogo,
                          sTendoanhnghiep = doanhNghiep.STenDn,
                          sDiachi = baiTuyenDung.SDiachicuthe,
                          FMucLuong = baiTuyenDung.FMucLuongtoithieu,
                          FMucLuongTD=baiTuyenDung.FMucluongtoida
                      }).ToList();
            ViewBag.TotalPages = Math.Ceiling((double)result.Count / pageSize);
            ViewBag.CurrentPage = pageNumber;
            List<TblDoanhnghiep> model1Data = _context.TblDoanhnghieps.ToList();
            ViewBag.model1Data = model1Data;


            return View("vDanhsachvieclam", result.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult btnGuithongtinUngTuyen(int PKsMabai)
        {
            HttpContext.Session.SetInt32("Ungtuyen", 0);
            if (PKsMabai != 0)
            {
                HttpContext.Session.SetInt32("Mabaituyendung", PKsMabai);
            }
            if (HttpContext.Session.GetInt32("FkSMaQuyen") == null && HttpContext.Session.GetString("PK_sEmail") == null)
            {
                return RedirectToAction("Login", "Taikhoan");
            }
            return View("vThongtinungtuyen");
        }
        [HttpPost]
        public IActionResult btnGuithongtinUngTuyen(IFormFile file, String txtGioithieu)
        {

            UploadFileModel up = new UploadFileModel();
            String slink = up.OnPostAsync(file, txtGioithieu);
            TblThongTinUngTuyen tblThongTinUngTuyen = new TblThongTinUngTuyen();
            tblThongTinUngTuyen.SCv = slink;
            tblThongTinUngTuyen.PkFkSMaUngVien = (long)HttpContext.Session.GetInt32("PKsMaUngVien");
            tblThongTinUngTuyen.PkFkSMaBai = (long)HttpContext.Session.GetInt32("Mabaituyendung");
            tblThongTinUngTuyen.SGioithieu = txtGioithieu;
            tblThongTinUngTuyen.DNgayGui = DateTime.Now;
            var check = _context.TblThongTinUngTuyens.Add(tblThongTinUngTuyen);
            _context.SaveChanges();
            if (check != null)
            {
                ViewBag.MS_028 = "Gui CV thanh cong";
            }
            return View("vThongtinungtuyen");
        }

        public IActionResult btnHienthidanhsachcv(bool? bTrangthai)
        {
            List<vdanhsachcvdaungtuyen> danhsachcv= _context.TblThongTinUngTuyens
                .Include(p=>p.PkFkSMaBaiNavigation)
                .Where(p=>p.PkFkSMaUngVien== (long)HttpContext.Session.GetInt32("PKsMaUngVien") && p.BTrangthai==bTrangthai)
                .Join(_context.TblDoanhnghieps,
                ungtuyen => ungtuyen.PkFkSMaBaiNavigation.FkSMaDn,
                doanhnghiep => doanhnghiep.PkSMaDn,
                (ungtuyen, doanhnghiep) => new { ungtuyen, doanhnghiep })
                .Join(_context.TblBaituyendungs,
                ungtuyen1 => ungtuyen1.ungtuyen.PkFkSMaBai,
                Baituyendung => Baituyendung.PkSMaBai,
                (ungtuyen1, Baituyendung) => new vdanhsachcvdaungtuyen
                {
                    PkFkSMaUngVien=ungtuyen1.ungtuyen.PkFkSMaUngVien,
                    PkFkSMaBai = ungtuyen1.ungtuyen.PkFkSMaBai,
                    sTenDN=ungtuyen1.doanhnghiep.STenDn,
                    SCv=ungtuyen1.ungtuyen.SCv,
                    DNgayGui=ungtuyen1.ungtuyen.DNgayGui,
                    sTenBai=Baituyendung.STenBai,
                    BTrangthai=ungtuyen1.ungtuyen.BTrangthai
                }).ToList();
            return View("vDanhsachcvungvien",danhsachcv);
        }
    }
}
