using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using test.ViewModel;

namespace test.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManagr;

        public RoleController(RoleManager<IdentityRole> roleManagr)
        {
            this.roleManagr = roleManagr;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task <IActionResult> New(RoleViewModel roleViewModel)
        {

            if(ModelState.IsValid ==true)
            {

                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = roleViewModel.RoleName;
           IdentityResult result=  await   roleManagr.CreateAsync(roleModel);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }



                //save db

            }
            return View(roleViewModel);
        }
    }
}
