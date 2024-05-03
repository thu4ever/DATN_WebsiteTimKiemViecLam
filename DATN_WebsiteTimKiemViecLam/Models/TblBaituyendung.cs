using System;
using System.Collections.Generic;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public partial class TblBaituyendung
    {
        public TblBaituyendung()
        {
            TblThongTinUngTuyens = new HashSet<TblThongTinUngTuyen>();
            PkSMaBai = 0;
            STenBai = "";
            SMoTa = "";
            SYeuCau = "";
            SQuyenLoi = "";
            FMucluongtoida = 0;
            FMucLuongtoithieu = 0;
            DTgTuyenDung = DateTime.Now.AddDays(15);
            DTgDangBai = DateTime.Now;
            ISoLuong = 0;
            SDiachicuthe = "";
            FNamKinhNghiem = 0;
        }

        public long PkSMaBai { get; set; }
        public string STenBai { get; set; } = null!;
        public string? SMoTa { get; set; }
        public string SYeuCau { get; set; } = null!;
        public string? SQuyenLoi { get; set; }
        public double? FMucLuongtoithieu { get; set; }
        public double? FNamKinhNghiem { get; set; }
        public DateTime DTgTuyenDung { get; set; }
        public int? ISoLuong { get; set; }
        public DateTime DTgDangBai { get; set; }
        public long FkSMaDn { get; set; }
        public int? ITrangthai { get; set; }
        public string? SDiachicuthe { get; set; }
        public double? FMucluongtoida { get; set; }

        public virtual TblDoanhnghiep FkSMaDnNavigation { get; set; } = null!;
        public virtual ICollection<TblThongTinUngTuyen> TblThongTinUngTuyens { get; set; }
    }
}
