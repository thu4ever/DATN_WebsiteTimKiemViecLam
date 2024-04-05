using System;
using System.Collections.Generic;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public partial class TblQuyen
    {
        public TblQuyen()
        {
            TblTaikhoans = new HashSet<TblTaikhoan>();
        }

        public long PkSMaQuyen { get; set; }
        public string STenQuyen { get; set; } = null!;
        public bool BTrangThai { get; set; }

        public virtual ICollection<TblTaikhoan> TblTaikhoans { get; set; }
    }
}
