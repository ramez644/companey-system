using test.Models;

namespace test.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        
         Department GetById(int id);
       

        void Insert(Department newdep);



        void Update(int id, Department newDepartment);



         void Delete(int id);
        
    }
}
