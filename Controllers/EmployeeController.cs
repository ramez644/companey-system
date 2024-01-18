using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repository;

namespace test.Controllers
{
    public class EmployeeController : Controller
    {
        // Entity context=new Entity();
        IEmployeeRepository EmpRepo;//=new EmployeeRepository();
        IDepartmentRepository DeptRepository;// = new DepartmentRepository();


        public IActionResult DetalisUsingPartial(int id)
        {
            Employee emp=EmpRepo.GetById(id);
            return PartialView("Details", emp);
        }
        public IActionResult Details(int id)
        {
            return View(EmpRepo.GetById(id));
        }

        public EmployeeController(IEmployeeRepository EmpRepos,IDepartmentRepository  DeptRepos)
        {
            //constracter fieldواللى على ايدك اليمين privatefieldsاللى على ايدك شمال ال
            EmpRepo = EmpRepos;
            DeptRepository = DeptRepos;
                
        }
        public IActionResult CheckSalary(int Salary)
        {
            if (Salary > 2000)
            {
                return Json(true);
            }

            return Json(false);
        }
        [Authorize] //check cookie
        public IActionResult Index()
        {
            //return View(context.Employees.ToList());
            return View(EmpRepo.GetAll());
        }
        public IActionResult Edit(int id)//get data from data base
        {
            //open view
            Employee empModel = EmpRepo.GetById(id);/*context.Employees.FirstOrDefault(e => e.Id==id);*/
            ViewData["deptList"] = DeptRepository.GetAll();//dep.Departments.ToList();
            
            return View(empModel);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id,Employee newEmp)
        {
            if (newEmp.Name!=null) {
                Employee oldEmp= EmpRepo.GetById(id);
               /* Employee oldEmp =*/ EmpRepo.Update(id, newEmp);//context.Employees.FirstOrDefault(e=>e.Id==id);
                if(oldEmp!=null)
                {
                    oldEmp.Salary=newEmp.Salary;
                    oldEmp.Name = newEmp.Name;
                    oldEmp.Address = newEmp.Address;
                    oldEmp.Dept_Id = newEmp.Dept_Id;
                    oldEmp.Image = newEmp.Image;
                    //context.SaveChanges();
                    return RedirectToAction("Index");


                }


            }
            ViewData["deptList"] = DeptRepository.GetAll();//context.Departments.ToList();

            return View("Edit", newEmp);

        }
        public IActionResult New()
        {
            ViewData["DeptDropDownList"] = DeptRepository.GetAll(); //context.Departments.ToList();

            return View();
        }

        [HttpPost]
        //call internal
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee newEmployee) {
        if (ModelState.IsValid)
            {
                try
                {

                    //context.Employees.Add(newEmployee);
                    EmpRepo.Insert(newEmployee);
                    //context.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    //lec 6 validation
                    ModelState.AddModelError(String.Empty, ex.Message.ToString());


                }




            }
            ViewData["DeptDropDownList"] = DeptRepository.GetAll(); //context.Departments.ToList();

            return View("New",newEmployee);
        
        }
        
    }
}
 