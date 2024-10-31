using System.ComponentModel.DataAnnotations;

namespace feliciano.PL.ViewModels
{
    public class LoginVM
    {

        [DataType(DataType.Password)]
  
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool RememberMe { get; set; }
    }
}
