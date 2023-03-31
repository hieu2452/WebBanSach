using WebBanSach.Models;
using Microsoft.EntityFrameworkCore;
using WebBanSach.Models.Datas;
using WebBanSach.Repository.Interface;

namespace WebBanSach.Repository
{
    public class NhaXbRepository : INhaXbRepository
    {
        public readonly DbBookStoreContext _context = null;

        public NhaXbRepository(DbBookStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<TNhaXuatBan> GetNXBs()
        {
            return _context.TNhaXuatBans.OrderBy(x => x.MaNxb);
        }
    }
}
