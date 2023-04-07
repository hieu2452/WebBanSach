using Microsoft.AspNetCore.Mvc;
using WebBanSach.Repository.Interface;

namespace WebBanSach.ViewComponents
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly ITheLoaiRepository _theLoaiRepository;

        public TheLoaiMenuViewComponent(ITheLoaiRepository theLoaiRepository)
        {
            _theLoaiRepository = theLoaiRepository;
        }

        public IViewComponentResult Invoke()
        {
            var theloai = _theLoaiRepository.GetTheLoais();
            return View(theloai);
        }
    }
}
