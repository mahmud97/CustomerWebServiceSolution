using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CustomerRegistration.Web.Helper
{
	public static class CaptchaHelper
	{


		private static readonly string recaptchaSecret = CoreAppSettings.GoogleApiKeyForCaptcha;
		private static readonly string apiAddress = "https://www.google.com/recaptcha/api/siteverify";

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		public static async Task<string> RecaptchaVerify(string recaptchaToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

		{
			string url = $"{apiAddress}?secret={recaptchaSecret}&response={recaptchaToken}";
			using (HttpClient httpClient = new HttpClient())
			{
				try
				{

					var responseString = httpClient.GetStringAsync(url).Result;
					return responseString;

				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
		}
	}
}