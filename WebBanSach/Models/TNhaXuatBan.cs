using System;
using System.Collections.Generic;

namespace WebBanSach.Models;

public partial class TNhaXuatBan
{
    public int MaNxb { get; set; }

    public string TenNxb { get; set; } = null!;

    public string? Url { get; set; }

    public virtual ICollection<TSach> TSaches { get; } = new List<TSach>();
}
