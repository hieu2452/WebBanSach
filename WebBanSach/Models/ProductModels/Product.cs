namespace WebBanSach.Models.ProductModels
{
    public class Product
    {
        public int MaSp { get; set; }
        public string? TenSp { get; set; }
        public string? TacGia { get; set; }
        public double? DonGia { get; set; }
        public int? MaTl { get; set; }
        public string? Anh { get;set; }
        public string? MoTa { get;set;}
        public bool? Active { get;set;}
    }
}
