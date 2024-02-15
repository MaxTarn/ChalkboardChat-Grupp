using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkBoardChat.Ui.Pages.Account
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;


        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            //var ue = Username;
            IdentityUser? UserToLogIn = await _userManager.FindByNameAsync(Username);
            if (UserToLogIn != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(UserToLogIn, Password, false, false);

                if (signInResult.Succeeded)
                {
                    //Om dirrigera användare till Members-sidan
                    return RedirectToPage("/Posts/Index");
                }
                else
                {
                    //fel lössenord
                }
            }
            return Page();
        }
    }
}