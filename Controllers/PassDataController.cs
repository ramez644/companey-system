using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.ViewModel;

namespace test.Controllers
{
    public class PassDataController : Controller
    {
        

        Entity context = new Entity();
        //passdata/testviewdata
        public IActionResult testViewData(int id)
        {
            Employee empModel= context.Employees.FirstOrDefault(e=>e.Id==id);
            string msg = "Hell";
            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("cairo");
            int temp = 44;
            string Color = "red";
           // ViewData["Message"] =msg;
           ViewBag.Message=msg;
            ViewData["brch"] = branches;
            ViewData["Temp"] = temp;
            ViewData["color"] =Color;



            return View(empModel);

        }
        public IActionResult testviewModel(int id) {
            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            string msg = "Hell";
            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("cairo");
            int temp = 44;
            string Color = "red";
            // ViewData["Message"] =msg;
            ViewBag.Message = msg;
            ViewData["brch"] = branches;
            ViewData["Temp"] = temp;
            ViewData["color"] = Color;

            //declare viewmodel
            EmoployeeWithManageAndBranchListViewModel empViewModel = new
                EmoployeeWithManageAndBranchListViewModel();
            //get data from model set to view model
            empViewModel.Message = msg;
            empViewModel.Temp= temp;
            empViewModel.Color = Color;
            empViewModel.Branches = branches;

            return View(empViewModel);


        }
    }
}
