using Microsoft.AspNetCore.Mvc;
using test.Models;

namespace test.Controllers
{
    public class BindController : Controller
    {
        //moadel binding map :action prameters with requset data(form data/query sreing /routedata)
        public IActionResult testPremitive(int id, string name, int age, string[] color)
        {

            return Content($"name={name},id={id}");



        }
       //bind/testcomplix/1?name=sd&managername=hiba&employees[0].name=ahmed
        public IActionResult testComplix( [Bind (include: "Id,Name")]Department dept)
        {


            return Content($"ok ");
        }
    }
}
