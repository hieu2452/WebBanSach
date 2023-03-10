using System;
using System.Collections.Generic;

namespace WebBanSach.Models;

public partial class TNgonNgu
{
    public int MaNg { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<TSach> TSaches { get; } = new List<TSach>();
}
