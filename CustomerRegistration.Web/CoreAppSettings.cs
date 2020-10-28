using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CustomerRegistration.Web
{
    public class CoreAppSettings
    {
        public static string GoogleApiKeyForCaptcha
        {
            get
            {
                return Setting<string>("GoogleApiKeyForCaptcha");
            }
        }

        public static string SendGridApiKey
        {
            get
            {
                return Setting<string>("SendGridApiKey");
            }
        }

        public static string MailTo
        {
            get
            {
                return Setting<string>("MailTo");
            }
        }





        private static T Setting<T>(string name)
        {
            string value = ConfigurationManager.AppSettings[name];

            if (value == null)
            {
                throw new Exception(String.Format("Could not find setting '{0}',", name));
            }

            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}