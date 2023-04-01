namespace WebBanSach.Models.Datas
{
    public class HoaDonModel
    {
        public int MaHD { get; set; }
        public string UserN { get; set; }

        public DateTime ngaytao { get; set; }
        public int? SDT { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }

        public List<BookDetailModel> bookDetail { get; set; }

        public double tongTien { get; set; }
    }
}
