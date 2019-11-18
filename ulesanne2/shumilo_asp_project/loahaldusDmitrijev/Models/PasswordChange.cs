using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shumilo_asp_project.Models
{
    public class PasswordChange
    {
        public string email { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
    }
}