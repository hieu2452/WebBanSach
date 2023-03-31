using WebBanSach.Models;
using WebBanSach.Models.Datas;

namespace WebBanSach.Repository.Interface
{
    public interface INhaXbRepository
    {
        IEnumerable<TNhaXuatBan> GetNXBs();
    }
}
