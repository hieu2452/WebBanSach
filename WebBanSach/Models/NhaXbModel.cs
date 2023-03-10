using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class NhaXbModel
    {
        [Key]
        public int MaNxb { get; set; }
        public string TenNxb { get; set; }
    }
}
