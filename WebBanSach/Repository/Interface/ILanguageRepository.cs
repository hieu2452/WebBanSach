using WebBanSach.Models;
using WebBanSach.Models.Datas;

namespace WebBanSach.Repository.Interface
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}
