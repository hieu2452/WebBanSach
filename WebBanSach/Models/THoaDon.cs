using System;
using System.Collections.Generic;

namespace WebBanSach.Models;

public partial class THoaDon
{
    public int MaHd { get; set; }

    public DateTime? NgayTao { get; set; }

    public int? Id { get; set; }

    public virtual TUser? IdNavigation { get; set; }

    public virtual ICollection<TChiTietHoaDon> TChiTietHoaDons { get; } = new List<TChiTietHoaDon>();
}
