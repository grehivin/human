using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dal.entities
{
    public partial class Roles
    {
        public Roles()
        {
            RolesAssignedToUsers = new HashSet<RolesAssignedToUsers>();
        }

        [Display(Name = "")]
        public int Id { get; set; }
        [Display(Name = "")]
        public string Role { get; set; }
        [Display(Name = "")]
        public bool? Enabled { get; set; }

        [Display(Name = "")]
        public virtual ICollection<RolesAssignedToUsers> RolesAssignedToUsers { get; set; }
    }
}
