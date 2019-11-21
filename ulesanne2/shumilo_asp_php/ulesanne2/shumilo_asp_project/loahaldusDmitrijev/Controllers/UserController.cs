using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using shumilo_asp_project.Models;

namespace shumilo_asp_project.Controllers
{
    public class UserController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();
        
        public string Post(RegisterUser registerUser)
        {
            string result = "";
            if (registerUser.password != registerUser.password_second) result= "Passwords do not match";
            else if (db.Users.Where(x => x.login == registerUser.email).FirstOrDefault() != null) result = "This user already exists";
            else
            {
                if (registerUser.email == "" || registerUser.password == "" || registerUser.password_second == "") return "some field is not filled";
                else
                {
                    HttpContext.Current.Session["email"] = registerUser.email;

                    string password = registerUser.password;
                    result = "Success";
                    User user = new User();
                    user.login = registerUser.email;
                    user.password = Hash.ComputeSha256Hash(password);
                    user.roleID = 1;
                    db.Users.Add(user);
                    db.SaveChanges();
                }


            }
            return result;
        }
        public string Put(PasswordChange user)
        {
            string result = "";

            string oldpassword = user.oldpassword;
            oldpassword = Hash.ComputeSha256Hash(oldpassword);

            string newpassword = user.newpassword;
            newpassword = Hash.ComputeSha256Hash(newpassword);

            if (user.oldpassword == "") result = "OldPassword null";
            else if (user.newpassword == "") result = "NewPassword null";
            else
            {
                if ((db.Users.Where(x => x.login == user.email).FirstOrDefault().password == oldpassword))
                {
                    User user_ = db.Users.Where(x => x.login == user.email).FirstOrDefault();
                    user_.password = newpassword;
                    db.SaveChanges();
                    result = "Sucess";
                }
                else
                {
                    result = "Old password Wrong";
                }
            }

            return result;
        }
    }
}
