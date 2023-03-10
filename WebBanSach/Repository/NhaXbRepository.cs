using WebBanSach.Models;
using Microsoft.EntityFrameworkCore;

namespace WebBanSach.Repository
{
    public class NhaXbRepository : INhaXbRepository
    {
        public readonly DbBookStoreContext _context = null;

        public NhaXbRepository(DbBookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<NhaXbModel>> GetNXBs()
        {
            return await _context.TNhaXuatBans.Select(x => new NhaXbModel()
            {
                MaNxb = x.MaNxb,
                TenNxb = x.TenNxb,
            }).ToListAsync();
        }
    }
}
