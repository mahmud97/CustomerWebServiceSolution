using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerRegistration.Web.Models
{
	public class CustomerVM
	{
		[Required(ErrorMessage = "You must provide Name")]
		[DisplayName("Name")]
		public string Name { get; set; }


		[Required(ErrorMessage = "You must provide an Email address")]
		[DisplayName("Email")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "You must provide Message")]
		[DisplayName("Your Message")]
		public string Message { get; set; }


		
		[Display(Name = "I have read and agree to ")]
		[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions!")]
		public bool IsTermsAccepted { get; set; }
	}
}