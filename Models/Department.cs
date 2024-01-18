using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name ="Dept Name")]
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
