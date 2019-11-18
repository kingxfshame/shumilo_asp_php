using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shumilo_asp_project.Models
{
    [Table("tblNimi")]
    public class Nimi
    {
        
        public int ID { get; set; }
        public string eestoni_nimi { get; set; }
        public string english_nimi { get; set; }
        public string sex { get; set; }
        public string status { get; set; }
        public string who_added { get; set; }
    }
}