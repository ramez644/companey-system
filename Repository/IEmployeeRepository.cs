using test.Models;

namespace test.Repository
{
    public interface IEmployeeRepository
    {
        Guid Id { get; set; }
        List<Employee> GetAll();


         Employee GetById(int id);



         void Insert(Employee newemp);




         void Update(int id, Employee newEmployee);




         void Delete(int id);
        List<Employee> GetByDeptId(int deptId);
      
    }

}

