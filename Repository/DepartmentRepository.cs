using test.Models;

namespace test.Repository
{
    public class DepartmentRepository:IDepartmentRepository
       
    {
        Entity context;//= new Entity()




        public DepartmentRepository(Entity db) { 
        
        context = db;
        
        }
        public List<Department> GetAll()
        {
            //List<Department> departments = new List<Department>();
            return context.Departments.ToList();

        }
        public Department GetById(int id)
        {
            Department department = context.Departments.FirstOrDefault(e => e.Id == id);
            return department;


        }

        public void Insert(Department newdep)
        {


            context.Departments.Add(newdep);
            context.SaveChanges();


        }
        public void Insrt(Department newdep)
        {


            context.Departments.Add(newdep);
            context.SaveChanges();


        }


        public void Update(int id, Department newDepartment)
        {

            Department oldDep = GetById(id);
            oldDep.Name = newDepartment.Name;
            oldDep.ManagerName = newDepartment.ManagerName;
          
            context.SaveChanges();



        }


        public void Delete(int id)
        {

            Department department = GetById(id);
            context.Departments.Remove(department);
            context.SaveChanges();

        }
    }
}
