using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using ProiectPAW.Models;
using ProiectPAW.Services.Interfaces;
using ProiectPAW.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Authentication;
using ProiectPAW.Services.Interfaces;
using System.Security.Policy;

namespace ProiectPAW.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthService(UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterModel.InputModel inputModel)
        {
            var user = new IdentityUser { Email = inputModel.Email };

            await _userStore.SetUserNameAsync(user, inputModel.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, inputModel.Email, CancellationToken.None);
            return await _userManager.CreateAsync(user, inputModel.Password);
        }

        public async Task<IActionResult> HandleUserRegistrationAsync(string email, string returnUrl)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                return new RedirectToPageResult("RegisterConfirmation", new { email, returnUrl });
            }
            else
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return new LocalRedirectResult(returnUrl);
            }
        }
        public async Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            return await _signInManager.GetExternalAuthenticationSchemesAsync();
        }


        public async Task<IActionResult> HandleUserLoginAsync(LoginModel.InputModel inputModel, string returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(inputModel.Email, inputModel.Password, inputModel.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return new LocalRedirectResult("/Home/ConectareSucces");
            }
            if (result.RequiresTwoFactor)
            {
                return new RedirectToPageResult("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = inputModel.RememberMe });
            }
            if (result.IsLockedOut)
            {
                return new RedirectToPageResult("./Lockout");
            }

            return null;
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                                                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}