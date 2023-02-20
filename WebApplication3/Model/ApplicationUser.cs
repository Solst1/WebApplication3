using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Model
{
	public class ApplicationUser : IdentityUser
	{
        public int Id { get; set; }

        public string fName { get; set; }
        public string lName { get; set; }

        public string Gender { get; set; }
        public string NRIC { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public DateTime bDate { get; set; }

        public IFormFile Resume { get; set; }
        public string? ResumeName { get; set; }

        public string whoami { get; set; }
	}
}

