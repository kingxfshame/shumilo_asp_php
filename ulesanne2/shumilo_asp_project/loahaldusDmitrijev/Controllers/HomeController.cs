using shumilo_asp_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shumilo_asp_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string filterbynimi = "ASC",string[] checkbox_check = null)
        {

            DataBaseContext db = new DataBaseContext();

            ViewBag.names = db.Nimed.OrderByDescending(x => x.eestoni_nimi);

            ViewBag.Title = "Home Page";

            ViewBag.user = db.Users;

            List<string> letters = new List<string>();
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                letters.Add(Convert.ToString(letter));
            }
            
            ViewBag.Letters = letters;
            ViewBag.Letters_Count = letters.Count;
            ViewBag.Checkbox = new string[letters.Count];
            if(checkbox_check == null)
            {
                checkbox_check = ViewBag.Letters.ToArray();
            }
            for (int i = 0; i < letters.Count; i++)
            {
                if (checkbox_check.Contains(letters[i]))
                    ViewBag.Checkbox[i] = "checked";

            }
            List<Nimi> selected = new List<Nimi>();

            for (int i = 0; i < checkbox_check.Length; i++)
            {
                if (filterbynimi == "ASC")
                    selected.AddRange ( db.Nimed.ToList().Where(x => x.eestoni_nimi[0].ToString() == checkbox_check[i]).OrderBy(x => x.eestoni_nimi));
                else if (filterbynimi == "DESC")
                    selected.AddRange(db.Nimed.ToList().Where(x => x.eestoni_nimi[0].ToString() == checkbox_check[i]).OrderByDescending(x => x.eestoni_nimi));


            }
            ViewBag.names = selected;


            //if (filterbynimi == "ASC")
            //{
            //    ViewBag.names = db.Nimed.ToList().Where(x => x.eestoni_nimi[0].ToString() == checkbox_a  ||  x.eestoni_nimi[0].ToString() == checkbox_b  || x.eestoni_nimi[0].ToString() == checkbox_c).OrderBy(x => x.eestoni_nimi);
            //    ViewBag.asc = "selected";
            //    ViewBag.desc = "";

            //    if (checkbox_a != "A")
            //        ViewBag.a = "";

            //    if (checkbox_b != "B")
            //        ViewBag.b = "";
            //    if (checkbox_c != "C")
            //        ViewBag.c = "";
            //}

            //else if (filterbynimi == "DESC")
            //{
            //    ViewBag.names = db.Nimed.ToList().Where(x => x.eestoni_nimi[0].ToString() == checkbox_a || x.eestoni_nimi[0].ToString() == checkbox_b || x.eestoni_nimi[0].ToString() == checkbox_c).OrderByDescending(x => x.eestoni_nimi);
            //    ViewBag.asc = "";
            //    ViewBag.desc = "selected";

            //    if (checkbox_a != "A")
            //        ViewBag.a = "";

            //    if (checkbox_b != "B")
            //        ViewBag.b = "";
            //    if (checkbox_c != "C")
            //        ViewBag.c = "";
            //}



            //ViewBag.user = db.Users.Where(x => x.login == "admin").FirstOrDefault();
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Title = "Register Page";
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            DataBaseContext db = new DataBaseContext();
            ViewBag.user = db.Users;
            ViewBag.names = db.Nimed;

            return View("index");
        }
        public ActionResult Profile()
        {
            DataBaseContext db = new DataBaseContext();
            ViewBag.user = db.Users;
            ViewBag.nimed = db.Nimed.OrderBy(x=> x.status);
            ViewBag.Title = "Profile Page";
            return View();
        }
        public ActionResult Edit(int ID)
        {
            DataBaseContext db = new DataBaseContext();
            return View(db.Nimed.Where(x => x.ID == ID).FirstOrDefault());
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Nimi i)
        {
            DataBaseContext db = new DataBaseContext();
            Nimi nimi = db.Nimed.Where(x => x.ID == i.ID).FirstOrDefault();
            nimi.eestoni_nimi = i.eestoni_nimi;
            nimi.english_nimi = i.english_nimi;
            nimi.sex = i.sex;
            nimi.who_added = i.who_added;

            db.SaveChanges();

            return RedirectToAction("Profile");
        }
    }

}
