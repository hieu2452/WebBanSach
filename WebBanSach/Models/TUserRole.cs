using System;
using System.Collections.Generic;

namespace WebBanSach.Models;

public partial class TUserRole
{
    public string? MoTa { get; set; }

    public string RoleId { get; set; } = null!;

    public virtual ICollection<TUser> TUsers { get; } = new List<TUser>();
}
