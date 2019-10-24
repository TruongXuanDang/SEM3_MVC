using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using T1807MVC.Constant;

namespace T1807MVC.Models
{
    public class LoginMember
    {
        public string token { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public Dictionary<string, string> Validate()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(email))
            {
                errors.Add("email", "Email is required");
            }
            else if (!Regex.IsMatch(email, ApiRegex.EMAIL_REGEX))
            {
                errors.Add("email", "Do not have format of email");
            }

            if (string.IsNullOrEmpty(password))
            {
                errors.Add("password", "Password is required");
            }

            return errors;
        }
    }
}