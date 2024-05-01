using DATN_WebsiteTimKiemViecLam.Models;
using DATN_WebsiteTimKiemViecLam.Service;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Ghostscript.NET.Rasterizer;
using NuGet.Common;
using System.Text.RegularExpressions;

namespace DATN_WebsiteTimKiemViecLam.Controllers
{
    public class DoanhnghiepController : Controller
    {
        private readonly TakePictureFromPdf _pdfProcessor;
        private readonly db_WebsiteTimkiemvieclamContext _context;
        public static long quyen = 0;
        public static long PK_sMabai=0;
        public DoanhnghiepController(db_WebsiteTimkiemvieclamContext context, TakePictureFromPdf pdfProcessor)
        {
            _context = context;
            _pdfProcessor = pdfProcessor;
        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy để kiểm tra xem chuỗi không chứa ký tự không phải số
            string pattern = @"^[0-9]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }
        public IActionResult btnThembaidang()
        {
            TblBaituyendung tblBaituyendung = new TblBaituyendung();
            return View("vDangtaibaituyendung", tblBaituyendung);
        }
        public bool CheckValidthembaidang(String txtTen , String txtMota, String txtYeucau, String txtQuyenloi, float txtMucluongthoithieu,float txtMucluongtoida, int txtNamkinhnghiem,string txtsoluong, int txtTrangthai)
        {
            if (txtTen == null && txtMota == null && txtYeucau == null && txtQuyenloi == null && txtMucluongthoithieu == 0 && txtMucluongtoida == 0 && txtNamkinhnghiem == 0)
                return false;
            if (txtTen == null)
                return false;
            if (txtMota == null)
                return false;
            if (txtYeucau == null)
                return false;
            if (txtQuyenloi == null) 
                return false;
            if(txtMucluongthoithieu==0)
                return false;
            if(txtMucluongtoida==0)
                return false;
            if(txtNamkinhnghiem==0)
                return false;
            if(!IsValidPhoneNumber(txtsoluong))
                return false;
                return true;
        }
        public int btnThembaidangg(TblBaituyendung tblBaituyendung)
        {
            if (CheckValidthembaidang(tblBaituyendung.STenBai, tblBaituyendung.SMoTa, tblBaituyendung.SYeuCau, tblBaituyendung.SQuyenLoi, (float)tblBaituyendung.FMucLuongtoithieu, (float)tblBaituyendung.FMucluongtoida, (int)tblBaituyendung.FNamKinhNghiem, tblBaituyendung.ISoLuong.ToString(), (int)tblBaituyendung.ITrangthai)== false)
                return 0;
            if (tblBaituyendung.DTgDangBai > DateTime.Now.Date)
            {
                tblBaituyendung.ITrangthai = 0;
            }
            else if (tblBaituyendung.DTgTuyenDung <= DateTime.Now.Date)
            {
                tblBaituyendung.ITrangthai = 2;
            }
            else
                tblBaituyendung.ITrangthai = 1;
            var check = _context.TblBaituyendungs.Add(tblBaituyendung);
            _context.SaveChanges();
            if (check != null)
            {
                ViewBag.MS_039 = "Them bai dang thanh cong";
                return 1;
            }
            return 0;
        }

        [HttpPost]
        public IActionResult btnThembaidang(TblBaituyendung tblBaituyendung)
        {
            tblBaituyendung.FkSMaDn = 5;
            tblBaituyendung.PkSMaBai = PK_sMabai;
            if (tblBaituyendung.DTgDangBai > DateTime.Now.Date)
            {
                tblBaituyendung.ITrangthai = 0;
            }
            else if (tblBaituyendung.DTgTuyenDung <=DateTime.Now.Date)
            {
                tblBaituyendung.ITrangthai = 2;
            }
            else 
                tblBaituyendung.ITrangthai = 1;
            if (PK_sMabai != 0)
            {
                var checkrecordupdate = _context.TblBaituyendungs.Update(tblBaituyendung);
                _context.SaveChanges();
                if (checkrecordupdate != null)
                {
                    ViewBag.MS_018 = "chinh sua thong tin bai dang thanh cong";
                    return View("vDangtaibaituyendung", tblBaituyendung);
                }
            }
            var check=_context.TblBaituyendungs.Add(tblBaituyendung);
            _context.SaveChanges();
            if (check != null)
            {
                ViewBag.MS_039 = "Them bai dang thanh cong";
                return RedirectToAction("hienthidanhsachbaidang");
            }
            return View("vDangtaibaituyendung", tblBaituyendung);
        }
        public IActionResult hienthidanhsachbaidang()
        {
            List<TblBaituyendung> tblBaituyendung = _context.TblBaituyendungs.Where(p => p.FkSMaDn == 5).ToList();
            return View("vQuanlybaidang", tblBaituyendung);
        }
        public IActionResult btnTimkiembaidang(String txtTencongviec)
        {
            List<TblBaituyendung> tblBaituyendung = _context.TblBaituyendungs.Where(p => p.STenBai.Contains(txtTencongviec)).ToList();
            return View("vQuanlybaidang", tblBaituyendung);
        }
        public IActionResult btnSuabaidang(long PKsMabai)
        {
            TblBaituyendung tblBaituyendung= _context.TblBaituyendungs.Where(p=>p.PkSMaBai.Equals(PKsMabai)).FirstOrDefault();
            PK_sMabai = PKsMabai;
            return View("vDangtaibaituyendung",tblBaituyendung);
        }
        [HttpPost]
        public IActionResult btnSuabaidang1(TblBaituyendung tblBaituyendung)
        {
            var checkexist = _context.TblBaituyendungs.Where(p => p.Equals(tblBaituyendung)).FirstOrDefault();
            if (checkexist != null)
            {
                tblBaituyendung.FkSMaDn = 5;
                DateTime dtupdate = tblBaituyendung.DTgDangBai.Date;
                tblBaituyendung.ITrangthai = dtupdate.Equals(DateTime.Now.Date) ? 1 : 0;
                var checkrecordupdate = _context.TblBaituyendungs.Add(tblBaituyendung);
                _context.SaveChanges();
                if (checkrecordupdate != null)
                {
                    ViewBag.MS_039 = "Sửa bai dang thanh cong";
                }
            }
            return View("vDangtaibaituyendung", tblBaituyendung);
        }
        public IActionResult btnTuchoiCV(long PkFkSMaBai, long PkFkSMaUngVien)
        {
            TblThongTinUngTuyen ChitietCVungvien = _context.TblThongTinUngTuyens
                .Where(p => p.PkFkSMaBai == PkFkSMaBai && p.PkFkSMaUngVien == PkFkSMaUngVien)
                .FirstOrDefault();
            if( ChitietCVungvien != null )
            {
                ChitietCVungvien.BTrangthai = false;
                _context.TblThongTinUngTuyens.Update(ChitietCVungvien); 
                var check=_context.SaveChanges();
                if(check>0)
                {
                    TblBaituyendung tblBaituyendung = _context.TblBaituyendungs.Where(p => p.PkSMaBai == PkFkSMaBai).FirstOrDefault();
                    TblUngVien tblUngVien= _context.TblUngViens.Where(p => p.PkSMaUngVien == PkFkSMaUngVien).FirstOrDefault();
                    string sub = "Thông báo từ FreeWork";
                    string content = "Chúng tôi rất tiếc khi phải thông báo cho bạn rằng CV của bạn cho công việc  " + tblBaituyendung.STenBai + "đã bị từ chối bởi nhà tuyển dụng. Nếu có bất cứ thắc mắc hay câu hỏi gì bạn có thể liên hệ trực tiếp với chúng tôi thông qua email chính thức: freework@gmail.com";
                    string sTennguoinhan = HttpContext.Session.GetString("PK_sEmail");
                    AutoSendEmaiil autoSendEmaiil = new AutoSendEmaiil();
                    autoSendEmaiil.SendEmail(tblUngVien.FkSEmail, sub, content);
                }    
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public IActionResult btnKetthucBaiDang(long PKsMabai)
        {
            TblBaituyendung tblBaituyendung = _context.TblBaituyendungs.Where(p => p.PkSMaBai == PKsMabai).FirstOrDefault();
            tblBaituyendung.DTgTuyenDung=DateTime.Now;
            _context.TblBaituyendungs.Update(tblBaituyendung);
            _context.SaveChanges();
            return Json(new { success = true });

        }
        public IActionResult btnXoabaidang(long PKsMabai)
        {
            TblBaituyendung tblBaituyendung = _context.TblBaituyendungs.Where(p=>p.PkSMaBai == PKsMabai).FirstOrDefault();
            _context.TblBaituyendungs.Remove(tblBaituyendung);
            _context.SaveChanges();
            return Json(new { success = true });
        }
        public int btnXoaBaiDang(long PKsMabai)
        {
            TblBaituyendung tblBaituyendung = _context.TblBaituyendungs.Where(p => p.PkSMaBai == PKsMabai).FirstOrDefault();
            if(tblBaituyendung!=null)
            {
                _context.TblBaituyendungs.Remove(tblBaituyendung);
                var check = _context.SaveChanges();
                if (check != 0)
                    return 1;
            }    
            return 0;
        }
        public IActionResult LoadStatus()
        {
            int check = 0;
            List<TblBaituyendung> lstBaituyendung = _context.TblBaituyendungs.ToList();
            foreach(TblBaituyendung item in lstBaituyendung)
            {
                if(item.DTgDangBai>DateTime.Now.Date)
                {
                    item.ITrangthai = 0;
                }
                else if(item.DTgTuyenDung<=DateTime.Now.Date)
                {
                    item.ITrangthai = 2;
                }
                else
                item.ITrangthai = 1;
            }
            foreach (TblBaituyendung item in lstBaituyendung)
            {
                _context.TblBaituyendungs.Update(item);
                check=_context.SaveChanges();
            }
            if(check!=0)
            return Json(new { success = true });
           
            return Json(new { success = false },"Load status bị lỗi");

        }
        public IActionResult GetItemBaidang()
        {
            List<TblBaituyendung> lstBaituyendung = _context.TblBaituyendungs.Where(p=>p.FkSMaDn==5).ToList();
            return View("vItemBaidang", lstBaituyendung);
        }
        public IActionResult btnDanglaiBaiDang()
        {
            return View();

        }
        public IActionResult btnChinhsuaCV()
        {
            return View();

        }
        public IActionResult btnTimkiemCVtheobaidang(long PkSMaBai)
        {
            var cvdaungtuyen = _context.TblThongTinUngTuyens
            .Where(p => p.PkFkSMaBai == PkSMaBai)
            .Join(
                _context.TblUngViens,
                ttUngtuyen => ttUngtuyen.PkFkSMaUngVien,
                Ungvien => Ungvien.PkSMaUngVien,
                (ttUngtuyen, Ungvien) => new vThongtinCVtheobaidang
                {
                    PkFkSMaUngVien=ttUngtuyen.PkFkSMaUngVien,
                    PkFkSMaBai=ttUngtuyen.PkFkSMaBai,
                    SEmail = Ungvien.FkSEmail,
                    BTrangthai = ttUngtuyen.BTrangthai,
                    DNgayGui = ttUngtuyen.DNgayGui,
                    sCV=ttUngtuyen.SCv
                }
             ).ToList();
            ViewBag.PKsMabai = PkSMaBai;
           
            return View("vdanhsachCV", cvdaungtuyen);

        }
        public async Task<IActionResult> ChitietCVungvien(long PkFkSMaUngVien, long PkFkSMaBai)
        {
            TblThongTinUngTuyen ChitietCVungvien =_context.TblThongTinUngTuyens.Where(p => p.PkFkSMaBai == PkFkSMaBai && p.PkFkSMaUngVien == PkFkSMaUngVien).FirstOrDefault();
           

            // Đưa base64Image vào ViewBag hoặc ViewModel để hiển thị trong view
           
            return View("vchinhsuatrangthaiCV");

        }
        public IActionResult btnGuiEmailchoungvien(long PkFkSMaUngVien, long PkFkSMaBai)
        {
            TblThongTinUngTuyen ChitietCVungvien = _context.TblThongTinUngTuyens.Where(p => p.PkFkSMaBai == PkFkSMaBai && p.PkFkSMaUngVien == PkFkSMaUngVien).FirstOrDefault();
            ChitietCVungvien.BTrangthai = true;
            _context.SaveChanges();
            return View("vGuiEmailchoungvien");

        }
        [HttpPost]
        public IActionResult btnGuiEmailchoungvien(string txtTieude, String txtNoidung)
        {
            return View("vGuiEmailchoungvien");
        }
    }
}
