using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dal.entities
{
    public partial class Users
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID Persona")]
        public int PersonId { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "La contraseña no coincide, por favor ingrese la misma contraseña ambas veces.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        [Display(Name = "Persona")]
        public virtual Persons Person { get; set; }
        [Display(Name = "Roles")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }

        public Users()
        {
            Id = 0;
            PersonId = 0;
            Username = string.Empty;
            Password = string.Empty;
            Enabled = false;
            Person = new Persons();
            UserRoles = new HashSet<UserRoles>();
        }

        public Users(int personId, string username, string password, bool enabled, Persons person, ICollection<UserRoles> rolesAssignedToUsers)
        {
            PersonId = personId;
            Username = username;
            Password = password;
            Enabled = enabled;
            Person = person;
            UserRoles = rolesAssignedToUsers;
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
