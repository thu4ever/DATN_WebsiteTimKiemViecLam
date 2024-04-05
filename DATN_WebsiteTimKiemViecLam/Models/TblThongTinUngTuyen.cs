using System;
using System.Collections.Generic;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public partial class TblThongTinUngTuyen
    {
        public long PkFkSMaUngVien { get; set; }
        public long PkFkSMaBai { get; set; }
        public DateTime DNgayGui { get; set; }
        public string? SGioithieu { get; set; }
        public string SCv { get; set; } = null!;
        public bool BTrangthai { get; set; }

        public virtual TblBaituyendung PkFkSMaBaiNavigation { get; set; } = null!;
        public virtual TblUngVien PkFkSMaUngVienNavigation { get; set; } = null!;
    }
}
