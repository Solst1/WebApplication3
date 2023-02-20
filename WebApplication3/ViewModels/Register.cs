using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplication3.ViewModels
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter you first name")]
        public string fName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string lName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter your NRIC")]
        public string NRIC { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [MinLength(12, ErrorMessage = "Password has to be at least 12 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])[A-Za-z\\d$@$!%*?&]{12,}$",
            ErrorMessage = "Passwords must be at least 8 characters long and contain at least an " +
            "upper case letter, lower case letter, digit and a symbol")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your password again")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your birthdate")]
        [DataType(DataType.DateTime)]
        public DateTime bDate { get; set; }

        [Required(ErrorMessage = "Please submit your resume as a .docx or .pdf file")]
        [FileExtensions(Extensions = "docx,pdf", ErrorMessage = "Invalid file format, only .docx and .pdf")]
        public IFormFile Resume { get; set; }

        public string? ResumeName { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Description of yourself must be less than 300 characters")]
        public string whoami { get; set; }

    }
}
