using Demo.Models.Entities;
using Demo.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging;
using System.Security.Claims;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<ApplicationUser> UserManager;
        public readonly RoleManager<IdentityRole> RoleManager;
        public readonly SignInManager<ApplicationUser> SignInManager;


        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newUserVM)
        {

            if(ModelState.IsValid)
            {
                //use the service layer to add to DB 


                //the CreateAsync() function expects "ApplicationUser" but i 
                //only have the RegisterViewModel so i need to map it

                //Mapping
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = newUserVM.Username;
                applicationUser.Address = newUserVM.Address;
                applicationUser.PasswordHash = newUserVM.Password;

                IdentityResult result =  await UserManager.CreateAsync(applicationUser, newUserVM.Password);
                if(result.Succeeded)
                {
                    //create cookie that has id, name, role ONLY
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("color", "red"));

                    await UserManager.AddToRoleAsync(applicationUser, "User");

                    await SignInManager.SignInWithClaimsAsync(applicationUser, true, claims);
                    return RedirectToAction("Login","Account");
                }
                else
                {
                    var errors = result.Errors;
                    foreach (var errorItem in errors)
                        ModelState.AddModelError("Passowrd", errorItem.Description);
                }
            }

            return View(newUserVM);
        }


        [HttpGet]
        public async Task<IActionResult> RegisterAdmin()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdmin(RegisterViewModel newAdminVM)
        {

            if (ModelState.IsValid)
            {
                //use the service layer to add to DB 


                //the CreateAsync() function expects "ApplicationUser" but i 
                //only have the RegisterViewModel so i need to map it

                //Mapping
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = newAdminVM.Username;
                applicationUser.Address = newAdminVM.Address;
                applicationUser.PasswordHash = newAdminVM.Password;

                IdentityResult result = await UserManager.CreateAsync(applicationUser, newAdminVM.Password);
                if (result.Succeeded)
                {
                    //create cookie that has id, name, role ONLY
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("color", "red"));

                    await UserManager.AddToRoleAsync(applicationUser, "Admin");


                    await SignInManager.SignInWithClaimsAsync(applicationUser, true, claims);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    var errors = result.Errors;
                    foreach (var errorItem in errors)
                        ModelState.AddModelError("Passowrd", errorItem.Description);
                }
            }

            return View(newAdminVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loggedUser)
        {
            if(ModelState.IsValid)
            {
                //check if user is in db
                ApplicationUser userRowFromDB =  await UserManager.FindByNameAsync(loggedUser.Username);
                if(userRowFromDB != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(userRowFromDB, loggedUser.Password);
                    if (found)
                    {
                        await SignInManager.SignInAsync(userRowFromDB, loggedUser.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else ModelState.AddModelError("", "Invalid Password");
                }
                ModelState.AddModelError("", "Username Not Found");
            }
            return View(loggedUser);
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
