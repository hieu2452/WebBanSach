using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;
using WebBanSach.Models;
using WebBanSach.Models.Datas;

namespace WebBanSach.Controllers
{
    public class UserController : Controller
    {

        private readonly DbBookStoreContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(DbBookStoreContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;   
        }

        public IActionResult Profile()
        {
            string userif = HttpContext.Session.GetString("UserInfo");

            TUser user = new TUser();

            user = JsonSerializer.Deserialize<TUser>(userif);


            return View(user);
        }

        [HttpGet]
        public IActionResult SuaThongTin(int makh)
        {
            var user = _context.TUsers.SingleOrDefault(x => x.Id == makh);
            return View(user);
        }

        [HttpPost]
        public IActionResult SuaThongTin(TUser user)
        {
            if (ModelState.IsValid)
            {
                var oldUser = _context.TUsers.Find(user.Id);
                string pic = UploadImage(user.AnhFile);
                oldUser.AnhDaiDien = pic;
                oldUser.UserN = user.UserN;
                oldUser.DiaChi = user.DiaChi;
                oldUser.Sdt = user.Sdt;
                /*_context.Entry(user).State = EntityState.Modified;*/
                _context.SaveChanges();
                string userif = HttpContext.Session.GetString("UserInfo");

                TUser userkh = new TUser();

                userkh = JsonSerializer.Deserialize<TUser>(userif);
                userkh.UserN = user.UserN;
                userkh.Sdt = user.Sdt;
                userkh.DiaChi = user.DiaChi;
                userkh.AnhDaiDien = pic;
                string updateUser = JsonSerializer.Serialize(userkh);
                HttpContext.Session.SetString("UserInfo", updateUser);
                return RedirectToAction("Profile", "User");
            }
            return View(user);
        }


        private string UploadImage(IFormFile file)
        {

            string folderPath = "users/profilepictures/";
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
            file.CopyToAsync(new FileStream(serverPath, FileMode.Create));

            return uniqueFileName;
        }

        private bool IsImageFileTypeAllowed(string fileExtension)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            return allowedExtensions.Contains(fileExtension.ToLower());
        }

    }
}
