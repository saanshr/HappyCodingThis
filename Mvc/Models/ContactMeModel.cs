using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace HappyCodingThis.SitefinityWebApp.Mvc.Models
{
    public class ContactMeModel
    {
	   [Display(Name="First Name")]
	   [Required(ErrorMessage = "First Name is required.")]
	   public string FirstName { get; set; }

	   [Display(Name="Last Name")]
	   [Required(ErrorMessage = "Last Name is required.")]
	   public string LastName { get; set; }

	   [Display(Name="Email Address")]
	   [Required(ErrorMessage = "Email is required.")]
	   [EmailAddress(ErrorMessage = "Email is not valid")]
	   public string Email { get; set; }

	   public string CommentQuestion { get; set; }
    }
}