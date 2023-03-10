using WebBanSach.Models;

namespace WebBanSach.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetCategorys();
    }
}
