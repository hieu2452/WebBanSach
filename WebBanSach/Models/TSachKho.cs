using System;
using System.Collections.Generic;

namespace WebBanSach.Models;

public partial class TSachKho
{
    public int MaKho { get; set; }

    public int MaSach { get; set; }

    public int? SoLuong { get; set; }

    public virtual TKho MaKhoNavigation { get; set; } = null!;

    public virtual TSach MaSachNavigation { get; set; } = null!;
}
