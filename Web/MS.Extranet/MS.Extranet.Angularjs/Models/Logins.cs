using System.ComponentModel.DataAnnotations;

namespace MS.Extranet.Angularjs.Models
{
    public class Logins
    {
        public class Login
        {
            public string Email { get; set; }

            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }
        
        public class RecoverPassword
        {
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class Register
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Surname")]
            public string Surname { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "##PasswordsNotMatch##")]
            public string ConfirmPassword { get; set; }

            public bool AcceptedConditions { get; set; }
        }
    }
    
}