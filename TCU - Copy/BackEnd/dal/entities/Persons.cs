using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class Persons
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Apellidos")]
        public string Lastname { get; set; }
        [Display(Name = "e-Mail")]
        public string Email { get; set; }

        [Display(Name = "Usuario")]
        public virtual ICollection<Users> Users { get; set; }
        [Display(Name = "Cursos")]
        public virtual ICollection<PersonCourses> PersonCourses { get; set; }

        public Persons()
        {
            Id = 0;
            Name = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Users = new HashSet<Users>();
            PersonCourses = new HashSet<PersonCourses>();
        }

        public Persons(string name, string lastname, string email, ICollection<Users> user, ICollection<PersonCourses> coursesByPerson)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Users = user;
            PersonCourses = coursesByPerson;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string name = "    \"Nombre\": " + Name + ",\n";
            string lastName = "    \"Apellidos\": " + Lastname + ",\n";
            string email = "    \"eMail\": " + Email + ",\n";

            return "Persona \n{\n" + id + name + lastName + email + "}";
        }
    }
}
