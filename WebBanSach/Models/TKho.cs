using System;
using System.Collections.Generic;

namespace WebBanSach.Models;

public partial class TKho
{
    public int MaKho { get; set; }

    public string? TenKho { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<TSachKho> TSachKhos { get; } = new List<TSachKho>();
}
