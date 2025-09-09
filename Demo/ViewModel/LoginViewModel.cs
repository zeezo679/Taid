using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModel
{
    public class LoginViewModel
    {

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
