using System.ComponentModel.DataAnnotations;

namespace feliciano.PL.ViewModels
{
    public class ResetPasswordVM
    {
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmedPassword { get; set; }

        public string Token { get; set; }
        public string Email { get; set; }
    }
}
