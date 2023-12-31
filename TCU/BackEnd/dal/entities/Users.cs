﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bend.dal.entities
{
    public partial class Users
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido, por favor ingrese un valor.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo es requerido, por favor ingrese un valor.")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido, por favor ingrese un valor.")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        [Display(Name = "Correo electrónico")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "La contraseña es necesaria para realizar el registro del usuario.")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener mínimo 8 caracteres.", MinimumLength = 8)]
        [RegularExpression(@"[a-zA-Z0-9!@#$%^&*_]+$", ErrorMessage = "La contraseña debe estar compuesta por letras, números y caracteres especiales (!@#$%^&*_).")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        /* [Required(ErrorMessage = "Debe confirmar la contraseña para realizar el registro del usuario.")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener mínimo 8 caracteres.", MinimumLength = 8)]
        [RegularExpression(@"[a-zA-Z0-9!@#$%^&*_]+$", ErrorMessage = "La contraseña debe estar compuesta por letras, números y caracteres especiales (!@#$%^&*_).")]
        [Compare("Password", ErrorMessage = "La contraseña no coincide, por favor ingrese la misma contraseña ambas veces.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmación de contraseña")]
        public string ConfirmPassword { get; set; } // */
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        [Display(Name = "Contenidos por usuario")]
        public virtual ICollection<UserContents> UserContents { get; set; }
        [Display(Name = "Cursos por usuario")]
        public virtual ICollection<UserCourses> UserCourses { get; set; }
        [Display(Name = "Respuestas por usuario")]
        public virtual ICollection<UserResponses> UserResponses { get; set; }
        [Display(Name = "Roles por usuario")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }

        public Users()
        {
            Id = 0;
            UserName = string.Empty;
            Password = string.Empty;
            Enabled = false;
            Name = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            UserRoles = new HashSet<UserRoles>();
            UserCourses = new HashSet<UserCourses>();
        }

        public Users(string username, string password, bool enabled, string name, string lastname, string email, ICollection<UserRoles> rolesAssignedToUsers, ICollection<UserCourses> coursesByPerson)
        {
            UserName = username;
            Password = password;
            Enabled = enabled;
            Name = name;
            LastName = lastname;
            Email = email;
            UserCourses = coursesByPerson;
            UserRoles = rolesAssignedToUsers;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string name = "    \"Nombre\": " + Name + ",\n";
            string lastName = "    \"Apellidos\": " + LastName + ",\n";
            string email = "    \"eMail\": " + Email + ",\n";
            string username = "    \"Usuario\": " + UserName + ",\n";
            string enabled = "    \"¿Habilitado?\": " + Enabled + "\n";

            return "Usuario \n{\n" + id + name + lastName + email + username + enabled + "}";
        }
    }
}
