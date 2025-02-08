using FullStackMon.Models;
using FullStackMon.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        public AccountController
            (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel UserFromRequest)
        {
            if(ModelState.IsValid)
            {
                //save Db
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName = UserFromRequest.Name,
                    PasswordHash = UserFromRequest.Password,
                    Address = UserFromRequest.Address,
                };
                IdentityResult result=
                    await  userManager.CreateAsync(appUser,UserFromRequest.Password);
                if (result.Succeeded)
                {
                    //add to Admin Role
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    //Create Cooike
                    await signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    //reason ==>enduser as modelstate error
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }
            return View("Register", UserFromRequest);
        }

        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel UserFromRequest)
        {
            if (ModelState.IsValid == true)
            {
                //check account is valid
               ApplicationUser userFromDb=
                    await userManager.FindByNameAsync(UserFromRequest.UserName);

                if (userFromDb != null)
                {
                   bool found=await userManager.CheckPasswordAsync
                        (userFromDb, UserFromRequest.Password);
                    if (found == true)
                    {
                        //create cookie
                        await signInManager.SignInAsync(userFromDb, UserFromRequest.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }

                ModelState.AddModelError("", "User name or password in valid");
                //cooie
            }
            return View("Login",UserFromRequest);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
