using DATN_WebsiteTimKiemViecLam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DATN_WebsiteTimKiemViecLam.Controllers
{
    public class DoanhnghiepController : Controller
    {
        private readonly db_WebsiteTimkiemvieclamContext _context;
        public static long quyen = 0;
        public static long PK_sMabai=0;
        public DoanhnghiepController(db_WebsiteTimkiemvieclamContext context)
        {
            _context = context;
        }
        public IActionResult btnThembaidang()
        {
            TblBaituyendung tblBaituyendung = new TblBaituyendung();
            return View("vDangtaibaituyendung", tblBaituyendung);
        }
        [HttpPost]
        public IActionResult btnThembaidang(TblBaituyendung tblBaituyendung)
        {
            if (PK_sMabai != 0)
            {
                tblBaituyendung.FkSMaDn = 5;
                tblBaituyendung.PkSMaBai=PK_sMabai;
                DateTime dtupdate = tblBaituyendung.DTgDangBai.Date;
                tblBaituyendung.ITrangthai = dtupdate.Equals(DateTime.Now.Date) ? 1 : 0;
                var checkrecordupdate = _context.TblBaituyendungs.Update(tblBaituyendung);
                _context.SaveChanges();
                if (checkrecordupdate != null)
                {
                    ViewBag.MS_018 = "chinh sua thong tin bai dang thanh cong";
                    return View("vDangtaibaituyendung", tblBaituyendung);
                }
            }
            tblBaituyendung.FkSMaDn = 5;
            DateTime dt= tblBaituyendung.DTgDangBai.Date;
            tblBaituyendung.ITrangthai =  dt.Equals(DateTime.Now.Date) ? 1 : 0;
            var check=_context.TblBaituyendungs.Add(tblBaituyendung);
            _context.SaveChanges();
            if (check != null)
            {
                ViewBag.MS_039 = "Them bai dang thanh cong";
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
        public IActionResult btnXoaBaiDang()
        {
            return View();
        }
        public IActionResult btnKetthucBaiDang()
        {
            return View();

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
                    SEmail = Ungvien.FkSEmail,
                    BTrangthai = ttUngtuyen.BTrangthai,
                    DNgayGui = ttUngtuyen.DNgayGui
                }
    )
    .ToList();

            return View();

        }
        public IActionResult btnGuiEmailchoungvien()
        {
            return View();

        }
    }
}
