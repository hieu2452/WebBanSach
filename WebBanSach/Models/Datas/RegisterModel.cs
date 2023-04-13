using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models.Datas
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [RegularExpression("^\\d+", ErrorMessage = "Nhập số điện thoại")]
        public double SDT { get; set; }


        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
