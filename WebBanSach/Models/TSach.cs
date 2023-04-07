using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Models;

public partial class TSach
{
    public int MaSach { get; set; }

    public string TenSach { get; set; } = null!;

    public string TacGia { get; set; } = null!;

    public double? DonGia { get; set; }

    public int? SoLuong { get; set; }

    public int? MaTl { get; set; }

    public int? MaNxb { get; set; }

    public string? Anh { get; set; }

    public int? MaNg { get; set; }

    public string? Mota { get; set; }

    [NotMapped]
    public int? SoLuongMua { get; set; }

    [NotMapped]
    [Display(Name = "Tải ảnh lên")]
    public IFormFile? AnhFile { get; set; }

    public bool? InActive { get; set; }

    public double? GiamGia { get; set; }


    [NotMapped]
    [RegularExpression(@"^(?:100|[1-9][0-9]|[1-9])$", ErrorMessage = "The value must be between 1 and 100.")]
    public double? GiamGiaInput { get; set; }

    public virtual TNgonNgu? MaNgNavigation { get; set; }

    public virtual TNhaXuatBan? MaNxbNavigation { get; set; }

    public virtual TTheLoai? MaTlNavigation { get; set; }

    public virtual ICollection<TChiTietHoaDon> TChiTietHoaDons { get; } = new List<TChiTietHoaDon>();

    public virtual ICollection<TSachKho> TSachKhos { get; } = new List<TSachKho>();
}
