using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class UniqeNameAttribute:ValidationAttribute
    {
        public string Msg { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) {
                string name = value.ToString();
                Entity context = new Entity();
                Employee emp = context.Employees.FirstOrDefault(e => e.Name == name);
                if (emp == null)//uniqe
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("name already found");
            }
            return new ValidationResult("name required");



            //return base.IsValid(value, validationContext);
        }
    }
}
