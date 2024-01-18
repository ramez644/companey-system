using test.Models;

namespace test.Repository
{
    //crud (c=>creat ,R=>read,U=>update ,D=>delete)
    public class EmployeeRepository:IEmployeeRepository
    {


        Entity context ; //=new Entity();
        //ask
        public EmployeeRepository(Entity db)
        {
            context = db;
        }
        public Guid Id { get; set; }
        public EmployeeRepository()
        {
            Id = Guid.NewGuid();
        }
        public List<Employee> GetAll()
        {
            //List<Department> departments = new List<Department>();
            return context.Employees.ToList();

        }
        public Employee GetById(int id) {
        Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            return employee;

        
        }
        public Employee GetByd(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            return employee;


        }
        public void Insert(Employee newemp) { 
        
        
        context.Employees.Add(newemp);
            context.SaveChanges();

        
        }


        public void Update(int id,Employee newEmployee) {
        
        Employee oldEmp=GetById(id);
            oldEmp.Name= newEmployee.Name;
            oldEmp.Address= newEmployee.Address;    
            oldEmp.Salary= newEmployee.Salary;  
            oldEmp.Dept_Id= newEmployee.Dept_Id;
           oldEmp.Image=newEmployee.Image;
            context.SaveChanges();



        }


        public void Delete(int id) {

            Employee employee = GetById(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
   
        }

        public List<Employee> GetByDeptId(int deptId)
        {

            return context.Employees.Where(e=>e.Dept_Id==deptId).ToList();
        }
    }



   
}
