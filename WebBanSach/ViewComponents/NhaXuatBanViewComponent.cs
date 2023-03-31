using Microsoft.AspNetCore.Mvc;
using WebBanSach.Repository.Interface;

namespace WebBanSach.ViewComponents
{
    public class NhaXuatBanViewComponent : ViewComponent
    {
        private readonly INhaXbRepository _nhaXbRepository;

        public NhaXuatBanViewComponent(INhaXbRepository nhaXbRepository)
        {
            _nhaXbRepository = nhaXbRepository;
        }

        public IViewComponentResult Invoke()
        {
            var nhaxb = _nhaXbRepository.GetNXBs();
            return View(nhaxb);
        }
    }
}
