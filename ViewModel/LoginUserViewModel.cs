using System.ComponentModel.DataAnnotations;

namespace test.ViewModel
{
    public class LoginUserViewModel
    {
        [Required]
      public string UserName { get; set;}
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set;}
        public Boolean RememberMe { get; set;}

    }
}
