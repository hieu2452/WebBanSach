using WebBanSach.Models;
using WebBanSach.Models.Datas;

namespace WebBanSach.Repository.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<TTheLoai> GetCategorys();
    }
}
