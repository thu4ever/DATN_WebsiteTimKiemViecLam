namespace DATN_WebsiteTimKiemViecLam.Models
{
    public class vChitietvieclam
    {
        public long PkSMaBai { get; set; }
        public string STenBai { get; set; } = null!;
        public string SYeuCau { get; set; } = null!;
        public string? SQuyenLoi { get; set; }
        public double? FMucLuongtoithieu { get; set; }
        public double? FNamKinhNghiem { get; set; }
        public DateTime DTgTuyenDung { get; set; }
        public int? ISoLuong { get; set; }
        public DateTime? DTgDangBai { get; set; }
        public long FkSMaDn { get; set; }
        public int? ITrangthai { get; set; }
        public string? SDiachicuthe { get; set; }
        public string? SDiachi { get; set; }
        public double? FMucluongtoida { get; set; }
        public string STenDn { get; set; } = null!;
        public string SLogo { get; set; } = null!;
        public string? SMota { get; set; }
    }
}
