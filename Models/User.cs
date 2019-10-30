using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using T1807MVC.Constant;

namespace T1807MVC.Models
{
    public class User
    {
        public int id { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [DisplayName("Avatar")]
        public string avatar { get; set; }
        [DisplayName("Phone")]
        public string phone { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("Introduction")]
        public string introduction { get; set; }
        [DisplayName("Gender")]
        public int gender { get; set; }
        [DisplayName("Birthday")]
        public string birthday { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }

        public int DemoField { get; set; }
        public int Status { get; set; } //1.Active | 0.Deactive | -1.Deleted
        public enum UserStatus { Active = 1, Deactive = 0, Deleted = -1};

        public Dictionary<string, string> Validate()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(firstName))
            {
                errors.Add("firstName", "First Name is required");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                errors.Add("lastName", "Last Name is required");
            }
            if (string.IsNullOrEmpty(password))
            {
                errors.Add("password", "Password is required");
            }
            if (string.IsNullOrEmpty(email))
            {
                errors.Add("email", "Email is required");
            }
            else if (!Regex.IsMatch(email, ApiRegex.EMAIL_REGEX))
            {
                errors.Add("email", "Do not have format of email");
            }

            if (string.IsNullOrEmpty(birthday))
            {
                errors.Add("birthday", "Birthday is required");
            }

            if (string.IsNullOrEmpty(avatar))
            {
                errors.Add("avatar", "Avatar is required");
            }

            if (string.IsNullOrEmpty(phone))
            {
                errors.Add("phone", "Phone is required");
            }

            if (string.IsNullOrEmpty(address))
            {
                errors.Add("address", "Address is required");
            }
            return errors;
        }
    }
}