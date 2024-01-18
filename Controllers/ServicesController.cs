using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using test.Filters;
using test.Repository;
namespace test.Controllers
{ 
    
       [Authorize] 
       //[MyFilter]
    public class ServicesController : Controller
    {
    
        public IActionResult TestClaims()
        {
            string name = User.Identity.Name;
            Claim IdClaim=User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier);

            return Content("Claim to user Id =" + IdClaim.Value);
        }
        [AllowAnonymous]
        public IActionResult testFilter()
        {
            return Content("hi");
        }

        IEmployeeRepository EmpRepo;
        private readonly IConfiguration config;

        public ServicesController(IEmployeeRepository empRepo,IConfiguration config)
        {
            EmpRepo = empRepo;
            this.config = config;
        }
        public IActionResult Index()
        {

            string Name=config.GetSection("ProjectName").Value;
            ViewBag.ID = EmpRepo.Id;
            return View();
        }
    }
}
