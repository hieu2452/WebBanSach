using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*using Newtonsoft.Json;*/
using WebBanSach.Models;
using WebBanSach.Models.Datas;
using WebBanSach.Repository.Interface;
using System.Text.Json;
using static NuGet.Packaging.PackagingConstants;

namespace WebBanSach.Controllers
{
    public class BookController : Controller
    {
        DbBookStoreContext _context = new DbBookStoreContext();
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(/*DbBookStoreContext context*/ IBookRepository bookRepository,
           ILanguageRepository languageRepository,
           IWebHostEnvironment webHostEnvironment)
        {
            /* _context = context;*/
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel();
            /*asdsdasdas*/
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {

            if (ModelState.IsValid)
            {
                if (bookModel.AnhDaiDien != null)
                {
                    bookModel.Anh = await UploadImage(bookModel.AnhDaiDien);
                }

                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            return View();
        }

        private async Task<string> UploadImage(IFormFile file)
        {

            string folderPath = "books/cover/";
            // Get the file extension
            string fileExtension = Path.GetExtension(file.FileName);

            // Generate a unique file name
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{fileExtension}";

            // Combine the folder path and the unique file name
            string filePath = Path.Combine(folderPath, uniqueFileName);

            // Get the server path
            string serverPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

            // Check if the file type is allowed
            if (!IsImageFileTypeAllowed(fileExtension))
            {
                throw new ArgumentException("Only image files of type .jpg, .jpeg, .png, .gif are allowed.");
            }

            // Copy the file to the server
            await file.CopyToAsync(new FileStream(serverPath, FileMode.Create));

            return uniqueFileName;
        }

        private bool IsImageFileTypeAllowed(string fileExtension)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            return allowedExtensions.Contains(fileExtension.ToLower());
        }


        [Authorize(Policy = "AdminPolicy")]
        [HttpGet]
        public async Task<IActionResult> Edit(int masach)
        {
            var book = await _bookRepository.GetById(masach);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TSach book)
        {
/*            if (ModelState.IsValid)
            {

                await _bookRepository.UpdateBook(book);
                return RedirectToAction("LoadBook", "Home");
            }*/

            if (ModelState.IsValid)
            {
                var oldBook = _context.TSaches.Find(book.MaSach);

                if (oldBook == null)
                {
                    return NotFound();
                }

                oldBook.TenSach = book.TenSach;
                oldBook.TacGia = book.TacGia;
                oldBook.Mota = book.Mota;
                oldBook.DonGia = book.DonGia;
                oldBook.SoLuong = book.SoLuong;
                oldBook.MaTl = book.MaTl;
                oldBook.MaNg = book.MaNg;
                oldBook.MaNxb = book.MaNxb;
                oldBook.Anh = await UploadImage(book.AnhFile);

                await _context.SaveChangesAsync();
                return RedirectToAction("LoadBook", "Home");
               }
                // If the model state is not valid, redisplay the form with validation errors


                return View(book);
        }



        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Delete(int masach)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "";
                var rs = await _bookRepository.DeleteBook(masach);
                if (rs)
                {
                    TempData["message"] = "Khong xoa dc san pham";
                    return RedirectToAction("LoadBook", "Home");

                }
                return RedirectToAction("LoadBook", "Home");
            }
            return RedirectToAction("LoadBook", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(TSach sach)
        {
            var book = await _bookRepository.GetById(sach.MaSach);

            string cartJson = HttpContext.Session.GetString("Cart");

            List<CartItem> cartItems = string.IsNullOrEmpty(cartJson) ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(cartJson);

            CartItem cartItem = new CartItem()
            {
                MaSach = book.MaSach,
                TenSach = book.TenSach,
                TacGia = book.TacGia,
                DonGia = book.DonGia,   
                SoLuong = sach.SoLuongMua,
                MoTa = book.Mota,
                Anh = book.Anh
            };

            CartItem itemInCart = cartItems.FirstOrDefault(x => x.MaSach == book.MaSach);

            if (itemInCart != null)
            {
                itemInCart.SoLuong += sach.SoLuongMua;
            }
            else
            {
                cartItems.Add(cartItem);
            }
            string updatedCartJson = JsonSerializer.Serialize(cartItems);
            HttpContext.Session.SetString("Cart", updatedCartJson);


            return RedirectToAction("BookDetails","Home", new { masach = book.MaSach });
        }

    }
}
