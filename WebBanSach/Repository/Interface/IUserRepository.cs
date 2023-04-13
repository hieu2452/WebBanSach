using WebBanSach.Models;

namespace WebBanSach.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<TUser>> GetAllUser();

        TUser GetUserById(int userid);

        IEnumerable<TUserRole> GetRole();
    }
}
