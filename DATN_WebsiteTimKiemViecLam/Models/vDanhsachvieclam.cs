namespace DATN_WebsiteTimKiemViecLam.Models
{
    public class vDanhsachvieclam
    {
        public vDanhsachvieclam() { }
        public long PkSMaBai { get; set; }
        public long FkSMaDn { get; set; }
        public string STenBai { get; set; } = null!;
        public string? sTendoanhnghiep { get; set; }
        public string SLogo { get; set; } = null!;
        public double? FMucLuong { get; set; }
        public double? FMucLuongTD { get; set; }
        public string? sDiachi { get; set; }

    }
}
