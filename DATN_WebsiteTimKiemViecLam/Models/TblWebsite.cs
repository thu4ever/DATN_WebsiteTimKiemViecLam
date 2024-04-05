using System;
using System.Collections.Generic;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public partial class TblWebsite
    {
        public long PkSMaWebsite { get; set; }
        public string STenWebsite { get; set; } = null!;
        public string SLink { get; set; } = null!;
        public long FkSMaDn { get; set; }

        public virtual TblDoanhnghiep FkSMaDnNavigation { get; set; } = null!;
    }
}
