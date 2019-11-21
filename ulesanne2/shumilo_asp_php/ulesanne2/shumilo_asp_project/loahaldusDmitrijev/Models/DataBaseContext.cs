using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shumilo_asp_project.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Nimi> Nimed { get; set; }
        //public DbSet<Role> Roles { get; set; }

        public DataBaseContext() : base("DbContext")
        {
            if (!Database.Exists())
                Database.Create();

            //Users.Add(new User()
            //{
            //    login = "artur.kexpa@gmail.com",
            //    password = Hash.ComputeSha256Hash("admin"),
            //    roleID = 2,
            //});
            //Nimed.Add(new Nimi()
            //{
            //    eestoni_nimi = "Artur",
            //    english_nimi = "Arthur",
            //    sex = "Male",
            //    status = "accept",
            //    who_added = "artur.kexpa@gmail.com",

            //});
            //Nimed.Add(new Nimi()
            //{
            //    eestoni_nimi = "Vassili",
            //    english_nimi = "Vasiliy",
            //    sex = "Male",
            //    status = "accept",
            //    who_added = "artur.kexpa@gmail.com",
            //});

            //Nimed.Add(new Nimi()
            //{
            //    eestoni_nimi = "Anna",
            //    english_nimi = "Anya",
            //    sex = "Female",
            //    status = "accept",
            //    who_added = "artur.kexpa@gmail.com",
            //});





            SaveChanges();
        }
    }
}