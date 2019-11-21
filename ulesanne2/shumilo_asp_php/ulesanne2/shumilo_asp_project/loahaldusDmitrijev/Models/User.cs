using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shumilo_asp_project.Models
{
    [Table("tblUsers")]
    public class User
    {
        public int ID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int roleID { get; set; }
    }
}