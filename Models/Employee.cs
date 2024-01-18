using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [UniqeName(Msg ="ay haga")]
        
        public string Name { get; set; }


        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Salary must be 4 numbers")]
        [Range(2000, 6000)]
        [Required]
        [Remote("CheckSalary", "Employee", ErrorMessage = "Salary mut be greater than2000")]//client side validation
        public int Salary { get; set; }
       [Required]
        [RegularExpression("(Alex|Menia|Sohag)")]
        public string? Address { get; set; }
        [RegularExpression(@"[a-z]+\.(jpg|png)")]
        public string Image { get; set; }
        [Display(Name ="Department")]
        [ForeignKey("department")]
        public int Dept_Id { get; set; }


        public virtual Department? department { get; set; }

    }
}
