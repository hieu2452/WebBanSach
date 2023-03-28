using WebBanSach.Models;
using WebBanSach.Models.Datas;

namespace WebBanSach.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetCategorys();
    }
}
