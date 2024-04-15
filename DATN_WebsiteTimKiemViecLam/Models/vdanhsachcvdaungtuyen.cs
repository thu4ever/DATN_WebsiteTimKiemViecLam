namespace DATN_WebsiteTimKiemViecLam.Models
{
    public class vdanhsachcvdaungtuyen
    {
        public long PkFkSMaUngVien { get; set; }
        public long PkFkSMaBai { get; set; }
        public string sTenDN { get; set; }
        public string sTenBai { get; set; }
        public DateTime DNgayGui { get; set; }
        public string SCv { get; set; } = null!;
        public bool? BTrangthai { get; set; }
    }
}
