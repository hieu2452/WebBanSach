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

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.TNgonNgus.Select(x => new LanguageModel()
            {
                MaNg = x.MaNg,
                Mota = x.Mota,
            }).ToListAsync();
        }
    }
}
