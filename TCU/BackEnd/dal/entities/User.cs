using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dal.entities
{
    public partial class User
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID Persona")]
        public int PersonId { get; set; }
        [Display(Name = "Usuario")]
        public string Username { get; set; }
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        [Display(Name = "Persona")]
        public virtual Person Person { get; set; }
        [Display(Name = "Roles")]
        public virtual ICollection<RolesByUser> RolesAssignedToUsers { get; set; }

        public User()
        {
            Id = 0;
            PersonId = 0;
            Username = string.Empty;
            Password = string.Empty;
            Enabled = false;
            Person = new Person();
            RolesAssignedToUsers = new HashSet<RolesByUser>();
        }

        public User(int personId, string username, string password, bool enabled, Person person, ICollection<RolesByUser> rolesAssignedToUsers)
        {
            PersonId = personId;
            Username = username;
            Password = password;
            Enabled = enabled;
            Person = person;
            RolesAssignedToUsers = rolesAssignedToUsers;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string pid = "    \"IDPersona\": " + PersonId + ",\n";
            string username = "    \"Usuario\": " + Username + ",\n";
            string enabled = "    \"¿Habilitado?\": " + Enabled + ",\n";

            return "Usuario \n{\n" + id + pid + username + enabled + "}";
        }
    }
}
