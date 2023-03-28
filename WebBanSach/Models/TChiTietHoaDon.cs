using System;
using System.Collections.Generic;

namespace WebBanSach.Models;

public partial class TChiTietHoaDon
{
    public int? SoLuong { get; set; }

    public int MaHd { get; set; }

    public int MaSach { get; set; }

    public virtual THoaDon MaHdNavigation { get; set; } = null!;

    public virtual TSach MaSachNavigation { get; set; } = null!;
}
