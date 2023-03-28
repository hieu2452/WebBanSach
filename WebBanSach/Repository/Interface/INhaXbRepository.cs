using WebBanSach.Models.Datas;

namespace WebBanSach.Repository.Interface
{
    public interface INhaXbRepository
    {
        Task<List<NhaXbModel>> GetNXBs();
    }
}
