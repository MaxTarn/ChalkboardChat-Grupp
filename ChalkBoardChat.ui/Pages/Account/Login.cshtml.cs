using ChalkBoardChat.App.Managers;
using ChalkBoardChat.Data.Database;
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
        private readonly AuthDbContext _authDbContext;

        public LoginModel(AuthDbContext authContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authDbContext = authContext;

        }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            UsersManager user = new(_authDbContext, _userManager, _signInManager);
            if (await user.CheckIfUserExists(Username))
            {
                var signinResult = await user.SignInUser(Username, Password);
                if (signinResult != null && signinResult.Succeeded)
                {
                    return RedirectToPage("/Posts/Index");
                }
            }
            return Page();
        }
    }
}