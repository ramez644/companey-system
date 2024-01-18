using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class StateManagmentController : Controller
    {
        public IActionResult SetCookie() {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires=DateTimeOffset.Now.AddHours(1);
            Response.Cookies.Append("name", "asmaa", cookieOptions);
            //presetend cookie 
            Response.Cookies.Append("age", "23");
            return Content("cookie saved");
        
        }
        public IActionResult GetCookie()
        {
            string name= Request.Cookies["name"];
            int age= int.Parse(Request.Cookies["age"]);
            return Content($" from cookie {name} {age}");
        }

        public IActionResult setSession()
        {
            HttpContext.Session.SetString("name","ahmed");
            HttpContext.Session.SetInt32("age", 32);
            return Content("seesion data saved");
        }

        public IActionResult getSessionData() {
           string name= HttpContext.Session.GetString("name");
         int age=   HttpContext.Session.GetInt32("age").Value;

            return Content($"data name={name} age={age}");

        }
        public IActionResult setTempData()
        {
            
            TempData["msg"] = "MESSAGE SET HELL";
            return Content("data sved");
        }
        public IActionResult get1()
        {
            string message = "EmptyMsg";
            if (TempData.ContainsKey("msg"))
            {
                // message=TempData["msg"].ToString();//normal read
                message = TempData.Peek("msg").ToString();
            }

            
            return Content("get1" + message);
        }


        public IActionResult get2()
        {

            string message = TempData["msg"].ToString();
            TempData.Keep("msg");
            return Content("get2" + message);
        }
    }
}
