using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models.Datas
{
    public class LanguageModel
    {
        [Key]
        public int MaNg { get; set; }
        public string Mota { get; set; }
    }
}
