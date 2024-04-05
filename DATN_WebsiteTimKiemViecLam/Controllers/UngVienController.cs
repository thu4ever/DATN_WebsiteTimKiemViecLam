using DATN_WebsiteTimKiemViecLam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Linq;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            int pageSize = 8; // Số lượng mục trên mỗi trang
            int pageNumber = (page ?? 1);

            var danhSachBaiTuyenDung = _context.TblBaituyendungs
              .Include(baiTuyenDung => baiTuyenDung.FkSMaDnNavigation) // Nạp dữ liệu từ bảng TblDoanhnghiep
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
            ViewBag.TotalPages = Math.Ceiling((double)danhSachBaiTuyenDung.Count / pageSize);
            ViewBag.CurrentPage = pageNumber;
            List<TblDoanhnghiep> model1Data =  _context.TblDoanhnghieps.ToList();
            ViewBag.model1Data = model1Data;


            return View("vDanhsachvieclam", danhSachBaiTuyenDung.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult btnHienthidanhsachDN()
        {
            List<TblDoanhnghiep> model1Data = _context.TblDoanhnghieps.ToList();
            ViewBag.model1Data = model1Data;
            return View("vDanhsachdoanhnghiep",model1Data);
        }
        public IActionResult btnHienthichitietvieclam(long PkSMaBai)
        {
             vChitietvieclam result= _context.TblBaituyendungs
              .Include(baiTuyenDung => baiTuyenDung.FkSMaDnNavigation)
              .Where(p=>p.PkSMaBai== PkSMaBai)
              .Select(baiTuyenDung => new vChitietvieclam
              {
                  PkSMaBai = baiTuyenDung.PkSMaBai,
                  STenBai = baiTuyenDung.STenBai,
                  SLogo = baiTuyenDung.FkSMaDnNavigation.SLogo,
                  STenDn = baiTuyenDung.FkSMaDnNavigation.STenDn,
                  SDiachicuthe = baiTuyenDung.SDiachicuthe,
                  FMucLuongtoithieu = baiTuyenDung.FMucLuongtoithieu,
                  SYeuCau=baiTuyenDung.SYeuCau,
                  SQuyenLoi=baiTuyenDung.SQuyenLoi,
                  SMota=baiTuyenDung.FkSMaDnNavigation.SMota,
                  ISoLuong=baiTuyenDung.ISoLuong,
                  ITrangthai=baiTuyenDung.ITrangthai,
                  DTgTuyenDung=baiTuyenDung.DTgTuyenDung,
                  FkSMaDn=baiTuyenDung.FkSMaDn,
                  FNamKinhNghiem=baiTuyenDung.FNamKinhNghiem,
                  FMucluongtoida=baiTuyenDung.FMucluongtoida,
                  DTgDangBai= baiTuyenDung.DTgDangBai
              })
              .FirstOrDefault();
            return View("vChitietvieclam",result);
        }
            public IActionResult btnHienthichitietDN(long FkSMaDn)
        {
            TblDoanhnghiep tblDoanhnghiep=_context.TblDoanhnghieps.Where(p=>p.PkSMaDn== FkSMaDn).FirstOrDefault();
            return View("vChitietdoanhnghiep", tblDoanhnghiep);
        } 
        public IActionResult btnTimkiemViecLam()
        {
            return View("vDanhsachtatcavieclam");
        }
        [HttpPost]
        public IActionResult btnTimkiemViecLam(int? page, String dThoigiandangtuyen, String txtkinhnghiem, String txtDiachi, String txtMucluong, String txtTencongviec)
        {
            if(txtTencongviec==null)
            {
                txtTencongviec = " ";
            }    
            if(txtDiachi==null)
            {
                txtDiachi = " ";
            }    
            if(txtkinhnghiem==null)
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
                .Where(u => u.FMucLuongtoithieu > float.Parse(txtMucluong))
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
                          FMucLuong = baiTuyenDung.FMucLuongtoithieu
                      }).ToList();
            ViewBag.TotalPages = Math.Ceiling((double)result.Count / pageSize);
            ViewBag.CurrentPage = pageNumber;
            List<TblDoanhnghiep> model1Data = _context.TblDoanhnghieps.ToList();
            ViewBag.model1Data = model1Data;


            return View("vDanhsachvieclam", result.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult btnGuithongtinUngTuyen()
        {
            return View("vThongtinungtuyen");
        }
        [HttpPost]
        public IActionResult btnGuithongtinUngTuyen(long PkSMaBai, String txtGioithieu, String slink)
        {
            return View("vThongtinungtuyen");
        }
        public IActionResult btnHienthidanhsachCV()
        {
            return View();
        }
    }
}
