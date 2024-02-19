using ChalkBoardChat.App.Managers;
using ChalkBoardChat.Data.Database;
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
        private readonly AuthDbContext _authDbContext;

        public string? Username { get; set; }
        public string? Password { get; set; }

        public RegisterModel(AuthDbContext authContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authDbContext = authContext;

        }

        public async Task<IActionResult> OnPost()
        {
            UsersManager user = new(_authDbContext, _userManager, _signInManager);

            if (await user.CheckIfUserExists(Username))
            {
                return Page(); // om användare finns
            }
            else
            {
                var createuser2 = await user.AddUser(Username, Password);

                if (createuser2.Succeeded)
                {

                    return RedirectToPage("Account/login"); //dirigera om användare till Post sidan


                }
                else
                {

                }

            }


            return Page();
        }
        public void OnGet()
        {

        }
    }
}