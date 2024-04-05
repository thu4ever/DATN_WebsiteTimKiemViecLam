using System;
using System.Collections.Generic;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public partial class TblTaikhoan
    {
        public TblTaikhoan()
        {
            TblDoanhnghieps = new HashSet<TblDoanhnghiep>();
            TblUngViens = new HashSet<TblUngVien>();
        }

        public string PkSEmail { get; set; } = null!;
        public string SMatkhau { get; set; } = null!;
        public long FkSMaQuyen { get; set; }

        public virtual TblQuyen FkSMaQuyenNavigation { get; set; } = null!;
        public virtual ICollection<TblDoanhnghiep> TblDoanhnghieps { get; set; }
        public virtual ICollection<TblUngVien> TblUngViens { get; set; }
    }
}
