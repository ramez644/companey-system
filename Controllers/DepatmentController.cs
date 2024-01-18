using Microsoft.AspNetCore.Mvc;
using test.Models;
using Microsoft.EntityFrameworkCore;
using test.Repository;
using Microsoft.AspNetCore.Authorization;

namespace test.Controllers
{
    public class DepatmentController : Controller
    {
      //
      //
      //
      //
      //
      //Entity context = new Entity();
        IDepartmentRepository DeptRepository;//=new DepartmentRepository();
        IEmployeeRepository EmployeeRepository;//= new EmployeeRepository();    
        //implement depndency injection
        [Authorize]//execute
        [ResponseCache(Duration =10)]
        public IActionResult ShowDepartmentEmployee()
        {

            List<Department> deptList=DeptRepository.GetAll();
            return View(deptList);

        }

        public IActionResult GetEmployeePerDepartment(int deptId)
        {
            List<Employee> emps = EmployeeRepository.GetByDeptId(deptId);
         // List<Employee> emps = context.Employees.Where(e => e.Dept_Id == deptId).ToList();
            return Json(emps);

        }
        public DepatmentController(IEmployeeRepository EmpRepo,IDepartmentRepository DeptRepo)
        {
            DeptRepository = DeptRepo;
            EmployeeRepository= EmpRepo;
            // DeptRepository = new DepartmentRepository();
            //EmpRepo = new EmployeeRepository();
        }
        public IActionResult Index()
        {
            List<Department> deptListModel = DeptRepository.GetAll();
            return View("Index",deptListModel);
        }

        [HttpGet]
        public IActionResult New() { 
        
        return View(new Department());
        }
        [HttpPost]
        public IActionResult SaveNew(Department dept)
        {
            if (dept.Name !=null)
            {
                //context.Departments.Add(dept);
                //context.SaveChanges();
                DeptRepository.Insert(dept);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New",dept);

            }
        }
        public IActionResult Details(int deptId)
        {
            return Content(deptId.ToString());
        }
    }
}
