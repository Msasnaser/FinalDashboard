using feliciano.DAL.Model;
using feliciano.PL.Helpers;
using feliciano.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Net;

namespace feliciano.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var ConfirmEmailLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

                    var email = new Email
                    {
                        Subject = "Confirm Email",
                        Recivers = model.Email,
                        Body = $"Please Confirm Your Account, Click : {ConfirmEmailLink}"
                    };

                    EmailSettings.SendEmail(email);
                    TempData["EmailConfirmationAlert"] = "Please check your email and confirm your account to complete the registration.";

                    return RedirectToAction(nameof(Login));
                }
            }

            return View(model);
        }



        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {

                    return RedirectToAction(nameof(Login));
                }
            }

            return RedirectToAction("Error", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var check = await userManager.CheckPasswordAsync(user, model.Password);
                    if (check)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            return View(model); 
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public async Task<IActionResult> SendRestPasswordUrl(PasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetLink = Url.Action("ResetPassword", "Account", new { token = WebUtility.UrlEncode(token), email = model.Email }, protocol: HttpContext.Request.Scheme);

                    var email = new Email()
                    {
                        Subject = "Reset Password",
                        Recivers = model.Email,
                        Body = resetLink
                    };
                    EmailSettings.SendEmail(email);

                    ViewBag.Message = "A reset link has been sent to your email address.";
                }
                else
                {
                    ViewBag.Error = "No account found with that email address.";
                }
            }
            return View(model);
        }

        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Invalid password reset token. Please try requesting a new reset link.";
                return RedirectToAction(nameof(ForgotPassword));
            }

            var model = new ResetPasswordVM
            {
                Token = token,
                Email = email
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var decodedToken = WebUtility.UrlDecode(model.Token);
                    var result = await userManager.ResetPasswordAsync(user, decodedToken, model.NewPassword);

                    if (result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Password reset successfully! You can now log in with your new password.";
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

    }
}
