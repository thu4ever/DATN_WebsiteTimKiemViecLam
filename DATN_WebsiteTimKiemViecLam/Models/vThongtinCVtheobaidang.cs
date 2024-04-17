namespace DATN_WebsiteTimKiemViecLam.Models
{
    public class vThongtinCVtheobaidang
    {
        public vThongtinCVtheobaidang() { }
        public long PkFkSMaUngVien { get; set; }
        public long PkFkSMaBai { get; set; }
        public string SEmail { get; set; } = null!;
        public string sCV { get; set; }
        public DateTime DNgayGui { get; set; }
        public bool? BTrangthai { get; set; }
    }
}
