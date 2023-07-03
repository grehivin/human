using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class Roles
    {
        [Display(Name = "ID Rol")]
        public int Id { get; set; }
        [Display(Name = "Rol")]
        public string Role { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool? Enabled { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }

        public Roles()
        {
            Id = 0;
            Role = string.Empty;
            Enabled = false;
        }

        public Roles(string descr, bool? enabled)
        {
            Role = descr;
            Enabled = enabled;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string descr = "    \"Rol\": " + Role + ",\n";
            string enabled = "    \"¿Habilitado?\": " + Enabled + ",\n";

            return "RolesPorUsuario \n{\n" + id + descr + enabled + "}";
        }
    }
}
