using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkBoardChat.Ui.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public string? Username { get; set; }
        public string? Password { get; set; }

        public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost()
        {
            IdentityUser newUser = new()
            {
                UserName = Username,
            };

            var createUserResult = await _userManager.CreateAsync(newUser, Password);
            if (createUserResult.Succeeded)
            {

                return RedirectToPage("Account/login"); //dirigera om användare till Post sidan


            }
            else
            {

            }
            return Page();
        }
        public void OnGet()
        {

        }
    }
}