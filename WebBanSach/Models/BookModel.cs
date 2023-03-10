using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebBanSach.Models
{
    public class BookModel
    {
        public int MaSach { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string TenSach { get; set; }

        [Required(ErrorMessage = "Please enter the author name")]
        public string TacGia { get; set; }

        [StringLength(500)]
        public string? MoTa { get; set; }

        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }

        public int MaTl { get; set; }
        public string? TheLoai { get; set; }

        public int? MaNxb { get; set; }
        public string? TenNXB { get; set; }

        //[Required(ErrorMessage = "Please choose the language of your book")]
        public int MaNg { get; set; }
        public string? NgonNgu { get; set; }

        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total pages of book")]
      /*  public int? TotalPages { get; set; }

        [Display(Name = "Choose the cover photo of your book")]*//*
        [Required]*/
        public IFormFile? AnhDaiDien { get; set; }
        public string? Anh { get; set; }
/*
        [Display(Name = "Choose the gallery images of your book")]
        [Required]*/
/*        public IFormFileCollection? GalleryFiles { get; set; }

        public List<GalleryModel>? Gallery { get; set; }

        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile? BookPdf { get; set; }
        [AllowNull]
        public string? BookPdfUrl { get; set; }*/
    }
}
