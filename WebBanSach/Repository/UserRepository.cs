using Microsoft.EntityFrameworkCore;
using WebBanSach.Models;
using WebBanSach.Models.Datas;
using WebBanSach.Repository.Interface;

namespace WebBanSach.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly DbBookStoreContext _context;

        public UserRepository(DbBookStoreContext context   )
        {
            _context = context;
        }

        public async Task<List<TUser>> GetAllUser()
        {
            return await _context.TUsers.OrderBy(x => x.Id).ToListAsync();
        }

        public IEnumerable<TUserRole> GetRole()
        {
            return _context.TUserRoles ;
        }

        public TUser GetUserById(int userid)
        {
            return  _context.TUsers.FirstOrDefault(x => x.Id == userid) ;
        }
    }
}
