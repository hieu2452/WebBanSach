using Microsoft.EntityFrameworkCore;
using WebBanSach.Models;
using WebBanSach.Models.Datas;
using WebBanSach.Repository.Interface;

namespace WebBanSach.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbBookStoreContext _context = null;

        public CategoryRepository(DbBookStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<TTheLoai> GetCategorys()
        {
            return _context.TTheLoais;
        }


    }
}
