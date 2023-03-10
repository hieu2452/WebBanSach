using WebBanSach.Models;

namespace WebBanSach.Repository
{
    public interface INhaXbRepository
    {
        Task<List<NhaXbModel>> GetNXBs();
    }
}
