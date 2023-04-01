using WebBanSach.Models;
using WebBanSach.Repository.Interface;

namespace WebBanSach.Repository
{
    public class TheLoaiRepository : ITheLoaiRepository
    {
        private readonly DbBookStoreContext _context = null;

        public TheLoaiRepository(DbBookStoreContext context)
        {
            _context = context;
        }


        public IEnumerable<TTheLoai> GetTheLoais()
        {
           return _context.TTheLoais;
        }
    }
}
