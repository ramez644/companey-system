using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class RouteController : Controller
    {

        //"{controller=Home}/{action=Index}/{id:int:range(2,10)}/{name:alpha?}")

        //action cant overload unliss in only condition if one of them post and another is get
        [HttpGet]
        public IActionResult New()
        {
            return Content("new get");
        }
        [HttpPost]
        public IActionResult New(int id,string name)
        {
            return Content("new2");
        }

        public IActionResult Index(string name)
        {
            return Content(name);
        }
        //  [Route("show/{msg:alpha}")]//wrong because it will be the only route 
        //[HttpGet]
        //[HttpGet("show/{msg:alpha}")]
        public IActionResult ShowMessage(string msg)
        {
            return Content(msg);
        }
    }
}
