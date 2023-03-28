using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models.Datas
{
    public class CategoryModel
    {
        [Key]
        public int MaTl { get; set; }
        public string TenTl { get; set; }
    }
}
