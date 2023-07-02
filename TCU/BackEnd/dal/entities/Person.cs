using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class Person
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Apellidos")]
        public string Lastname { get; set; }
        [Display(Name = "e-Mail")]
        public string Email { get; set; }
        [Display(Name = "ID Usuario")]
        public int UserId { get; set; }

        [Display(Name = "Usuario")]
        public virtual User User { get; set; }
        [Display(Name = "Cursos")]
        public virtual ICollection<CoursesByPerson> CoursesByPerson { get; set; }

        public Person()
        {
            Id = 0;
            Name = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            UserId = 0;
            User = new User();
            CoursesByPerson = new HashSet<CoursesByPerson>();
        }

        public Person(string name, string lastname, string email, int userId, User user, ICollection<CoursesByPerson> coursesByPerson)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            UserId = userId;
            User = user;
            CoursesByPerson = coursesByPerson;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string name = "    \"Nombre\": " + Name + ",\n";
            string lastName = "    \"Apellidos\": " + Lastname + ",\n";
            string email = "    \"eMail\": " + Email + ",\n";
            string userId = "    \"IDUsuario\": " + UserId + ",\n";

            return "Persona \n{\n" + id + name + lastName + email + userId + "}";
        }
    }
}
