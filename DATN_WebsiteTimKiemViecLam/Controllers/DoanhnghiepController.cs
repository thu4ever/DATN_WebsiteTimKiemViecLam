using DATN_WebsiteTimKiemViecLam.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN_WebsiteTimKiemViecLam.Controllers
{
    public class DoanhnghiepController : Controller
    {
        private readonly db_WebsiteTimkiemvieclamContext _context;
        public static long quyen = 0;
        public DoanhnghiepController(db_WebsiteTimkiemvieclamContext context)
        {
            _context = context;
        }
        public IActionResult btnThembaidang()
        {
            return View("vDangtaibaituyendung");
        }
        [HttpPost]
        public IActionResult btnThembaidang(TblBaituyendung tblBaituyendung)
        {
            tblBaituyendung.FkSMaDn = 5;
            DateTime dt= tblBaituyendung.DTgDangBai.Value.Date;
            tblBaituyendung.ITrangthai =  dt.Equals(DateTime.Now.Date) ? 1 : 0;
            var check=_context.TblBaituyendungs.Add(tblBaituyendung);
            _context.SaveChanges();
            if (check != null)
            {
                TempData["Message"] = "Thêm bài đăng thành công";
                return RedirectToAction("btnThembaidang");
            }
            return View("vDangtaibaituyendung");
        }
        public IActionResult hienthidanhsachbaidang()
        {
            return View("vQuanlybaidang");
        }
        public IActionResult btnSuabaidang()
        {
            return View();
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
        public IActionResult btnTimkiemCVtheobaidang()
        {
            return View();

        }
        public IActionResult btnGuiEmailchoungvien()
        {
            return View();

        }
    }
}
