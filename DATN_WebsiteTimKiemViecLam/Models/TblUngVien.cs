using System;
using System.Collections.Generic;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public partial class TblUngVien
    {
        public TblUngVien()
        {
            TblThongTinUngTuyens = new HashSet<TblThongTinUngTuyen>();
        }

        public long PkSMaUngVien { get; set; }
        public string? SHoTen { get; set; }
        public bool? BGioiTinh { get; set; }
        public string? SAnh { get; set; }
        public string? SSdt { get; set; }
        public string FkSEmail { get; set; } = null!;

        public virtual TblTaikhoan FkSEmailNavigation { get; set; } = null!;
        public virtual ICollection<TblThongTinUngTuyen> TblThongTinUngTuyens { get; set; }
    }
}
