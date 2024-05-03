using System;
using System.Collections.Generic;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public partial class TblDoanhnghiep
    {
        public TblDoanhnghiep()
        {
            TblBaituyendungs = new HashSet<TblBaituyendung>();
            this.STenDn = "";
            this.SMota = "";
            this.SSdt = "";
        }

        public long PkSMaDn { get; set; }
        public long SMasothue { get; set; }
        public string STenDn { get; set; } = null!;
        public string SLogo { get; set; } = null!;
        public string? SMota { get; set; }
        public string? SDiachi { get; set; }
        public string? SSdt { get; set; }
        public string FkSEmail { get; set; } = null!;

        public virtual TblTaikhoan FkSEmailNavigation { get; set; } = null!;
        public virtual ICollection<TblBaituyendung> TblBaituyendungs { get; set; }
    }
}
