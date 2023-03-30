namespace WebBanSach.Models.Datas
{
    public class CartItem
    {
        public int MaSach { get; set; }

        public string TenSach { get; set; } = null!;

        public string TacGia { get; set; } = null!;

        public string MoTa { get; set; }
        public double? DonGia { get; set; }

        public int? SoLuong { get; set; }

        public string Anh { get; set; }

    }
}
