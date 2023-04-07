using WebBanSach.Models;

namespace WebBanSach.Repository.Interface
{
    public interface ITheLoaiRepository
    {
        IEnumerable<TTheLoai> GetTheLoais();
    }
}
