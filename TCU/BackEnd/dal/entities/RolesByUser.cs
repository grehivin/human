using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class RolesByUser
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID Usuario")]
        public int UserId { get; set; }
        [Display(Name = "ID Rol")]
        public int RoleId { get; set; }

        public RolesByUser()
        {
            Id = 0;
            UserId = 0;
            RoleId = 0;
        }

        public RolesByUser(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string uid = "    \"IDUsuario\": " + UserId + ",\n";
            string rid = "    \"IDRol\": " + RoleId + ",\n";

            return "RolesPorUsuario \n{\n" + id + uid + rid + "}";
        }
    }
}
