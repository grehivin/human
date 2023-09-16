using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace bend.dal.entities
{
    public partial class UserRoles
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID Usuario")]
        public int UserId { get; set; }
        [Display(Name = "ID Rol")]
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }

        public UserRoles()
        {
            Id = 0;
            UserId = 0;
            RoleId = 0;
        }

        public UserRoles(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string uid = "    \"IDUsuario\": " + UserId + ",\n";
            string rid = "    \"IDRol\": " + RoleId + "\n";

            return "RolesPorUsuario \n{\n" + id + uid + rid + "}";
        }
    }
}
