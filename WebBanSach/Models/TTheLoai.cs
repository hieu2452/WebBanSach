using System;
using System.Collections.Generic;

namespace WebBanSach.Models;

public partial class TTheLoai
{
    public int MaTl { get; set; }

    public string TenTl { get; set; } = null!;

    public virtual ICollection<TSach> TSaches { get; } = new List<TSach>();
}
