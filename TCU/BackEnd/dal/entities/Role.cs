using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class Role
    {
        [Display(Name = "ID Rol")]
        public int Id { get; set; }
        [Display(Name = "Rol")]
        public string Descr { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool? Enabled { get; set; }

        public Role()
        {
            Id = 0;
            Descr = string.Empty;
            Enabled = false;
        }

        public Role(string descr, bool? enabled)
        {
            Descr = descr;
            Enabled = enabled;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string descr = "    \"Rol\": " + Descr + ",\n";
            string enabled = "    \"¿Habilitado?\": " + Enabled + ",\n";

            return "RolesPorUsuario \n{\n" + id + descr + enabled + "}";
        }
    }
}
