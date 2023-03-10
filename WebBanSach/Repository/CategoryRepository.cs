using Microsoft.EntityFrameworkCore;
using WebBanSach.Models;

namespace WebBanSach.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbBookStoreContext _context = null;

        public CategoryRepository(DbBookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryModel>> GetCategorys()
        {
            return await _context.TTheLoais.Select(x => new CategoryModel()
            {
                MaTl = x.MaTl,
                TenTl = x.TenTl,
            }).ToListAsync();
        }

        Task<List<CategoryModel>> ICategoryRepository.GetCategorys()
        {
            throw new NotImplementedException();
        }
    }
}
