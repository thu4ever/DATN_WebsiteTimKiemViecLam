using DATN_WebsiteTimKiemViecLam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Web;
using static System.Collections.Specialized.BitVector32;
using System.Web.Helpers;
using System.Text.RegularExpressions;
using NuGet.Protocol;

namespace DATN_WebsiteTimKiemViecLam.Controllers
{
    public class TaikhoanController : Controller
    {
        int? email = null;
        private readonly db_WebsiteTimkiemvieclamContext _context;
        public static long quyen=0;
        public TaikhoanController(db_WebsiteTimkiemvieclamContext context)
        {
            _context = context;
        }
        public bool IsContainNumberinPass(string password)
        {
            // Biểu thức chính quy để kiểm tra xem mật khẩu có chứa ít nhất một ký tự số hay không
            string pattern = @"^(?=.*\d).+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(password);
        }
        public bool IsContainSpecialChar(string password)
        {
            // Biểu thức chính quy để kiểm tra mật khẩu không chứa ký tự đặc biệt !, @, #, $, %, _
            string pattern = @"^[^!@#$%_]*$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(password);
        }
        public bool CheckValidDangki(string txtEmail,string  txtMatkhau, string txtMatkhaunhaplai,string iMaquyen)
        {
            if (txtEmail == null && txtMatkhau == null && txtMatkhaunhaplai == null&&iMaquyen==null)
                return false;
            if(!txtEmail.Contains("@"))
                return false;
            if(txtEmail.Contains("!")) 
                return false;
            if (!IsContainNumberinPass(txtMatkhau))
                return false; 
            if (IsContainSpecialChar(txtMatkhau))
                return false;
            if(txtMatkhau.Length!=8)
                return false;
            if(txtMatkhaunhaplai!=txtMatkhau)
                return false;
            return true;
        }
        public bool CheckValidDoimatkhau(string txtEmail, string txtMatkhaucu, string txtMatkhaumoi,string txtMatkhaumoinhaplai)
        {
            if(txtEmail == null &&txtMatkhaucu == null &&txtMatkhaumoi == null)
                return false;
            if(txtEmail==null)
                return false;
            if(txtMatkhaucu==null)
                return false;
            if(txtMatkhaumoi==null)
                return false;
            if (!IsContainNumberinPass(txtMatkhaumoi))
                return false;
            if (IsContainSpecialChar(txtMatkhaumoi))
                return false;
            if (txtMatkhaumoi.Length != 8)
                return false;
            if (txtMatkhaumoi!=txtMatkhaumoinhaplai)
                return false;
            TblTaikhoan tblTaikhoan= _context.TblTaikhoans.Where(p=>p.PkSEmail==txtEmail&&p.SMatkhau==txtMatkhaumoi).FirstOrDefault();
            if(tblTaikhoan==null)
                return false;
            return true;
        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy để kiểm tra xem chuỗi không chứa ký tự không phải số
            string pattern = @"^[0-9]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }
        public bool CheckValidthongtinUV(string txtHoten, string txtGioitinh, string txtAnh, string txtSodienthoai)
        {
            if(txtHoten==null&&txtGioitinh==null&&txtAnh==null&&txtSodienthoai==null)
                return false;
            if(txtHoten==null)
                return false;
            if(txtGioitinh==null)
                return false;
            if(txtAnh==null)
                return false;
            if(txtSodienthoai==null)
                return false;
            if(IsContainNumberinPass(txtHoten))
                return false;
            if (IsContainSpecialChar(txtHoten))
                return false;
            if(!IsValidPhoneNumber(txtSodienthoai))
                return false;
            if(txtSodienthoai.Length!=10)
                return false;
            return true;
        }
        public int btnChinhsuathongtinnUV_Click(string txtHoten, string txtGioitinh, string txtSodienthoai)
        {
            var file = Request.Form.Files["file"];
            TblUngVien tblUngVien = new TblUngVien();
            tblUngVien.SHoTen = txtHoten;
            tblUngVien.BGioiTinh = txtGioitinh == "nữ" ? true : false;
            tblUngVien.SSdt = txtSodienthoai;

            if (file != null && file.Length > 0)
            {
                try
                {
                    // Đọc dữ liệu từ tập tin ảnh vào một mảng byte
                    byte[] imageData;
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        imageData = memoryStream.ToArray();
                    }
                    // Chuyển đổi mảng byte thành chuỗi base64
                    string base64String = Convert.ToBase64String(imageData);
                    tblUngVien.SAnh = base64String;
                    string email = HttpContext.Session.GetString("PK_sEmail");
                    tblUngVien.FkSEmail = email;
                    var existingEntity = _context.TblUngViens.FirstOrDefault(e => e.FkSEmail == email);
                    if (existingEntity != null)
                    {
                        existingEntity.SHoTen = txtHoten;
                        existingEntity.BGioiTinh = txtGioitinh == "Nữ" ? true : false;
                        existingEntity.SSdt = txtSodienthoai;
                        existingEntity.SAnh = base64String;
                        _context.Update(existingEntity);
                        _context.SaveChanges();
                    }
                    return 1;
                }
                catch (Exception ex)
                {
                    // Xử lý nếu có lỗi
                    return 0;
                }
            }
            else
            {
                // Xử lý nếu không có tập tin được chọn
                return 0;
            }

        }
        public bool CheckExisitTaikhoan(String PKsEmail)
        {
            var check = _context.TblTaikhoans.FirstOrDefault(p => p.PkSEmail == PKsEmail);
            bool result = check != null ? true : false;
            return result;
        }
        public bool CheckDisableTaikhoan(String PKsEmail)
        {
            TblTaikhoan check = _context.TblTaikhoans.FirstOrDefault(p => p.PkSEmail == PKsEmail);
            bool result = check.FkSMaQuyen ==5 ? true : false;
            return result;
        }
        public ActionResult Login()
        {
           // return RedirectToAction("HomePage", "BaiUngTuyen");
            return View("Login");
        }
        public long Dangnhap_Click(String Email, String Matkhau)
        {
            TblTaikhoan result = _context.TblTaikhoans.FirstOrDefault(p => p.PkSEmail == Email && p.SMatkhau == Matkhau);
            return result.FkSMaQuyen;
        }
        [HttpPost]
        public ActionResult Login(String Email, String Matkhau)
        {
            TblTaikhoan result = _context.TblTaikhoans.FirstOrDefault(p => p.PkSEmail == Email && p.SMatkhau == Matkhau);
            if (result == null)
            {
                return View();
            }
            HttpContext.Session.SetInt32("FkSMaQuyen", Int32.Parse(result.FkSMaQuyen.ToString()));
            HttpContext.Session.SetString("PK_sEmail", result.PkSEmail.ToString());
            

            if (result.FkSMaQuyen==1)
            {
                TblUngVien tblUngVien = _context.TblUngViens.FirstOrDefault(p => p.FkSEmail == Email);
                //var savedText = sessionStorage.getItem(listKey);
                //// Truyền dữ liệu vào view
                //ViewBag.SavedText = savedText;
                if (tblUngVien != null)
                {
                    HttpContext.Session.SetString("Avatar", tblUngVien.SAnh);
                    HttpContext.Session.SetInt32("PKsMaUngVien", Int32.Parse(tblUngVien.PkSMaUngVien.ToString()));
                }
                if(HttpContext.Session.GetInt32("Mabaituyendung")!=null)
                {
                    return RedirectToAction("btnGuithongtinUngTuyen","Ungvien");
                }    
                return RedirectToAction("btnHienthidanhsachVL", "Ungvien");
            }
            else if(result.FkSMaQuyen==2)
            {
                TblDoanhnghiep tblDoanhnghiep = _context.TblDoanhnghieps.FirstOrDefault(p => p.FkSEmail == Email);
                if(tblDoanhnghiep!=null)
                {
                    HttpContext.Session.SetString("Avatar", tblDoanhnghiep.SLogo);
                    HttpContext.Session.SetInt32("PkSMaDn", Int32.Parse(tblDoanhnghiep.PkSMaDn.ToString()));

                }
                return RedirectToAction("hienthidanhsachbaidang", "Doanhnghiep");
            }
            else if (result.FkSMaQuyen==4)
            {
                return RedirectToAction("btnHienthidanhsachtaikhoan", "Taikhoan"); 
            }
            return View();
        }
        public ActionResult btnHienthidanhsachtaikhoan()
        {
            List<TblTaikhoan> lstTaikhoan = _context.TblTaikhoans.ToList();
            return View("vQuanlytaikhoan", lstTaikhoan);
        }
        public ActionResult ComfirmUser(long ungvien, long doanhnghiep)
        {
           
            if (ungvien != 1)
            {
                quyen = ungvien;
                return View("Resgiter");
            }
            else
            {
                quyen = doanhnghiep;
                return View("Resgiter");
            }
        }
        public int btnDangky_Click(long quyendki, String Email, String Matkhau)
        {
            TblTaikhoan taikhoan = new TblTaikhoan();
            taikhoan.SMatkhau = Matkhau;
            taikhoan.FkSMaQuyen = quyendki;
            taikhoan.PkSEmail = Email;

            var check = _context.TblTaikhoans.Add(taikhoan);
            _context.SaveChanges();
            if (check != null)
            return 1;
            return 0;
        }
        public ActionResult Resgiter()
        {
            return View("Resgiter");
        }
            [HttpPost]
        public ActionResult Resgiter( long quyendki,String Email, String Matkhau)
        {
            TblTaikhoan taikhoan= new TblTaikhoan();
            taikhoan.SMatkhau = Matkhau;
            taikhoan.FkSMaQuyen = quyendki;
            taikhoan.PkSEmail = Email;

            var check =_context.TblTaikhoans.Add(taikhoan);
            _context.SaveChanges();
            if (check != null)
            {
                if(quyendki==1)
                {
                    HttpContext.Session.SetString("PK_sEmail", Email);
                    return RedirectToAction("Login");
                }    
                HttpContext.Session.SetString("PK_sEmail", Email);
                return RedirectToAction("EditInForCompany");
            } 
            return View();
        }
        //public ActionResult EditInForCompany()
        //{
        //    return View();
        //}
        public ActionResult EditInForCompany()
        {
            return View();
        }
       [HttpPost]
        public ActionResult EditInForCompany(string tendoanhnghiep,string sodienthoai, string diachi, string mota,string masothue)
        {
            var file = Request.Form.Files["file"];
            TblDoanhnghiep doanhnghiep = new TblDoanhnghiep();
            doanhnghiep.SMasothue = Int32.Parse(masothue);
            doanhnghiep.STenDn = tendoanhnghiep;
            doanhnghiep.SDiachi = diachi;
            doanhnghiep.SSdt = sodienthoai;
            doanhnghiep.SMota = mota;
            String email= HttpContext.Session.GetString("PK_sEmail");
            doanhnghiep.FkSEmail = email != null ? email.ToString() : "error@gmail.com";

            
            if (file != null && file.Length > 0)
            {
                try
                {
                    // Đọc dữ liệu từ tập tin ảnh vào một mảng byte
                    byte[] imageData;
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        imageData = memoryStream.ToArray();
                    }

                    // Chuyển đổi mảng byte thành chuỗi base64
                    string base64String = Convert.ToBase64String(imageData);
                    doanhnghiep.SLogo = base64String;
                    var check = _context.TblDoanhnghieps.Add(doanhnghiep);
                    _context.SaveChanges();
                    if(check != null)
                    {
                        TempData["Message"] = "Chỉnh sửa thông tin đăng nhập thành công";
                        return RedirectToAction("Login");
                    }    
                    // Trả về chuỗi base64 cho client
                    return Content(base64String);
                }
                catch (Exception ex)
                {
                    // Xử lý nếu có lỗi
                    return Content("Error: " + ex.Message);
                }
            }
            else
            {
                // Xử lý nếu không có tập tin được chọn
                return Content("No file selected");
            }
        }
        public ActionResult btnChinhsuathongtinUV_Click()
        {
            TblUngVien check = _context.TblUngViens.Where(p => p.FkSEmail == HttpContext.Session.GetString("PK_sEmail")).FirstOrDefault();
            ViewBag.sHoten = check.SHoTen;
            ViewBag.SSdt = check.SSdt;
                return View("vThongtinUV");  
        }
        [HttpPost]
        public ActionResult btnChinhsuathongtinUV_Click(string txtHoten,string txtGioitinh, string txtSodienthoai)
        {
            var file = Request.Form.Files["file"];
            TblUngVien tblUngVien = new TblUngVien();
            tblUngVien.SHoTen = txtHoten;
            tblUngVien.BGioiTinh = txtGioitinh == "nữ" ? true : false;
            tblUngVien.SSdt = txtSodienthoai;

            if (file != null && file.Length > 0)
            {
                try
                {
                    // Đọc dữ liệu từ tập tin ảnh vào một mảng byte
                    byte[] imageData;
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        imageData = memoryStream.ToArray();
                    }
                    // Chuyển đổi mảng byte thành chuỗi base64
                     string base64String = Convert.ToBase64String(imageData);
                      tblUngVien.SAnh = base64String;
                    string email = HttpContext.Session.GetString("PK_sEmail");
                    tblUngVien.FkSEmail = email;
                    TblUngVien check = _context.TblUngViens.Where(p => p.FkSEmail == email).FirstOrDefault();
                    if (check == null)
                    {
                        _context.TblUngViens.Add(tblUngVien);
                        _context.SaveChanges();
                        return View("vThongtinUV");
                    }
                    var existingEntity = _context.TblUngViens.FirstOrDefault(e => e.FkSEmail == email);
                    if (existingEntity != null)
                    {
                        existingEntity.SHoTen = txtHoten;
                        existingEntity.BGioiTinh = txtGioitinh == "Nữ" ? true :false;
                        existingEntity.SSdt = txtSodienthoai;
                        existingEntity.SAnh = base64String;
                        _context.Update(existingEntity);
                        _context.SaveChanges();
                    }
                    return View("vThongtinUV");
                }
                catch (Exception ex)
                {
                    // Xử lý nếu có lỗi
                    return Content("Error: " + ex.Message);
                }
            }
            else
            {
                // Xử lý nếu không có tập tin được chọn
                return Content("No file selected");
            }
            
        }

        public bool btnDoimatkhauu_Click(string Email,string txtMatkhaucu, string txtMatkhaumoi)
        {
            TblTaikhoan check = _context.TblTaikhoans.Where(p => p.PkSEmail ==Email).FirstOrDefault();
            if (check != null)
            {
                if (check.SMatkhau == txtMatkhaucu)
                {
                    check.SMatkhau = txtMatkhaumoi;
                    _context.Update(check);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    ViewBag.MS_050 = "Mật khẩu cũ không đúng";
                }

            }
          //  return View("vDoimatkhau");
            return false;
        }
        public ActionResult btnDoimatkhau_Click()
        {
            return View("vDoimatkhau");
        }
        [HttpPost]
        public ActionResult btnDoimatkhau_Click(string txtMatkhaucu,string txtMatkhaumoi)
        {
            TblTaikhoan check = _context.TblTaikhoans.Where(p => p.PkSEmail == HttpContext.Session.GetString("PK_sEmail")).FirstOrDefault();
            if (check != null)
            {
                if(check.SMatkhau==txtMatkhaucu)
                {
                    check.SMatkhau= txtMatkhaumoi;
                    _context.Update(check);
                    _context.SaveChanges();
                    return View("Login");
                }
                else
                {
                    ViewBag.MS_050 = "Mật khẩu cũ không đúng";
                }
                    
            }
            return View("vDoimatkhau");
        }
        public ActionResult btnDangxuat() 
        {
            HttpContext.Session.Clear();
            return View("Login"); 
        }

    }
}
