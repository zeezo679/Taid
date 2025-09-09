using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModel
{
    public class RegisterViewModel
    {
        [MinLength(3)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
