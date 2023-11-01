using Autofac;
using Crud.Persistance.Features.Membership;
using CVBuilder.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CVBuilder.Web.Models
{
    public class RegisterModelVM
    {
       
        private  IConfiguration _configuration;
        public RegisterModelVM()
        {
            
        }
        public RegisterModelVM(IConfiguration configuration)
        {           
            _configuration = configuration;
        }
        internal void ResolveDependency(ILifetimeScope scope)
        {    
            _configuration = scope.Resolve<IConfiguration>();

        }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Your Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string? ReturnUrl { get; set; }
        public bool IsRegisterd { get; set; }
        [Display(Name ="Chose a Profile Picture")]
        public IFormFile? ProfilePicture {  get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Token { get; set; }
        public Boolean? MailSendStatus { get; set; }
      
    }
}
