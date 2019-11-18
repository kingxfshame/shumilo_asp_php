using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shumilo_asp_project.Models
{
    public class LoginUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public int roleID { get; set; }
    }
}