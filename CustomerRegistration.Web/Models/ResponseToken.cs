using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerRegistration.Web.Models
{
	public class ResponseToken
	{
		public DateTime challenge_ts { get; set; }
		public float score { get; set; }
		public List<string> ErrorCodes { get; set; }
		public bool Success { get; set; }
		public string hostname { get; set; }
	}
}