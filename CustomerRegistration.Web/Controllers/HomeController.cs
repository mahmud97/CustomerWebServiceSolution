using CustomerRegistration.Web.Helper;
using CustomerRegistration.Web.Models;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerRegistration.Web.Controllers
{
	public class HomeController : Controller
	{

		public string SetToken(string _token)
		{
			Session["Token"] = _token;
			return "true";
		}


		public ActionResult Index()
		{
			return View();
		}
		public ActionResult PrivacyPolicy()
		{
			ViewBag.Message = "Privacy Policy page.";

			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Index(CustomerVM model)
		{
			ResponseToken response = new ResponseToken();
			string sendGridKey = CoreAppSettings.SendGridApiKey;

			if (response.score == 0)
			{

				var responseString = CaptchaHelper.RecaptchaVerify((string)Session["Token"]).Result; ;
				response = JsonConvert.DeserializeObject<ResponseToken>(responseString);

			}
			if (response.score < 0.5)
			{
				ModelState.AddModelError("CaptchaFail", "Captcha verification failed. Please enter again ");
			}

			if (ModelState.IsValid)
			{
				SendMail(model, sendGridKey);
				return RedirectToAction("Thanks", "Home");
			}

			return View(model);
		}

		public ActionResult Thanks()
		{
			return View();
		}


		private void SendMail(CustomerVM model, string key)
		{

			try
			{
				var apikey = key;
				var client = new SendGridClient(apikey);
				var from = new EmailAddress(model.Email);
				var subject = "General Query";
				var to = new EmailAddress(CoreAppSettings.MailTo);
				var plainTextContent = "";
				var htmlContent = "<p> Name: " + model.Name + "</p>";
				htmlContent = htmlContent + "<p> Email: " + model.Email + "</p>";
				htmlContent = htmlContent + "<p> Message: " + model.Message + "</p>";
				var message = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
				var response = client.SendEmailAsync(message);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}



	}
}