using System.ComponentModel.DataAnnotations;

namespace feliciano.PL.ViewModels
{
    public class PasswordVM
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
