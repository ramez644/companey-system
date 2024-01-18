using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using test.Models;
using test.ViewModel;

namespace test.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = await userManager.FindByNameAsync(userVm.UserName);
                //create cookie 



                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVm.Password);

                    if (found == true)
                    {
                        // cookie
                        await signInManager.SignInAsync(userModel, userVm.RememberMe);
                        return RedirectToAction("Index", "Employee");
                    }

                }
                ModelState.AddModelError("", "user name or password wrong");
            }

            return View(userVm);
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //mapping
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Address = newUserVM.Address;
                userModel.PasswordHash = newUserVM.Password;
                //save db
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, "Student");
                    await signInManager.SignInAsync(userModel, false);//id name roles
                                                                      //   List<Claim> claims = new List<Claim>();
                                                                      //    claims.Add(new Claim("color", "red"));
                                                                      //await signInManager.SignInWithClaimsAsync(userModel, false, claims);
                                                                      //create cookie

                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var erroritem in result.Errors)
                    {
                        ModelState.AddModelError("Password", erroritem.Description);

                    }
                }
            }
            return View(newUserVM);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddAdmin(RegisterUserViewModel newUserVm)
        {


            if (ModelState.IsValid)
            {
                //mapping
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVm.UserName;
                userModel.Address = newUserVm.Address;
                userModel.PasswordHash = newUserVm.Password;
                //save db
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVm.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, "Admin");
                    await signInManager.SignInAsync(userModel, false);//id name roles
                                                                      //   List<Claim> claims = new List<Claim>();
                                                                      //    claims.Add(new Claim("color", "red"));
                                                                      //await signInManager.SignInWithClaimsAsync(userModel, false, claims);
                                                                      //create cookie

                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var erroritem in result.Errors)
                    {
                        ModelState.AddModelError("Password", erroritem.Description);

                    }
                }
            }
            return View(newUserVm);

        }
    }
}

          
        

