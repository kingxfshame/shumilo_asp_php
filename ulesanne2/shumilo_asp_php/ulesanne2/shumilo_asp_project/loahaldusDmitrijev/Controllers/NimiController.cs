using shumilo_asp_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shumilo_asp_project.Controllers
{
    public class NimiController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();
        public string Post(Nimi nimi)
        {
            string result = "";
            if (nimi.eestoni_nimi == "") result = "Nativ name null";
            else if (nimi.english_nimi == "") result = "Foreign name null";
            else
            {
                Nimi nimed = new Nimi();
                nimed.eestoni_nimi = nimi.eestoni_nimi;
                nimed.english_nimi = nimi.english_nimi;
                nimed.sex = nimi.sex;
                nimed.status = nimi.status;
                nimed.who_added = nimi.who_added;
                db.Nimed.Add(nimed);
                db.SaveChanges();
                result = "Success";
            }

            return result;
        }
        public string Put(int id,bool status)
        {

            string result = "";
            if ((db.Nimed.Where(x => x.ID == id).FirstOrDefault() != null))
            {
                Nimi value = (db.Nimed.Where(x => x.ID == id).FirstOrDefault());
                if(status == true)
                {
                    value.status = "accept";
                }
                else
                {
                    value.status = "denied";
                }
                db.SaveChanges();
            }
                return result;
        }
    }
}
