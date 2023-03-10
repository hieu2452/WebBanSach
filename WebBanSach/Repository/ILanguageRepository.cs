using WebBanSach.Models;

namespace WebBanSach.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}
