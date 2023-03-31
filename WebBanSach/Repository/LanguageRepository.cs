using Microsoft.EntityFrameworkCore;
using WebBanSach.Models;
using WebBanSach.Models.Datas;
using WebBanSach.Repository.Interface;

namespace WebBanSach.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly DbBookStoreContext _context = null;

        public LanguageRepository(DbBookStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<TNgonNgu> GetLanguages()
        {
            return _context.TNgonNgus;
        }
    }
}
