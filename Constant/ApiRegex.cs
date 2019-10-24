using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1807MVC.Constant
{
    public class ApiRegex
    {
        public const string EMAIL_REGEX = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public const string LINK_MP3_REGEX = @".*\.mp3$";
    }
}