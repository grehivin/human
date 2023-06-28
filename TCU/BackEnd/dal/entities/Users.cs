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
        public Users()
        {
            Persons = new HashSet<Persons>();
            RolesAssignedToUsers = new HashSet<RolesAssignedToUsers>();
        }

        [Display(Name = "")]
        public int Id { get; set; }
        [Display(Name = "")]
        public int? PersonId { get; set; }
        [Display(Name = "")]
        public string Username { get; set; }
        [Display(Name = "")]
        public string Password { get; set; }
        [Display(Name = "")]
        public bool? Enabled { get; set; }

        [Display(Name = "")]
        public virtual Persons Person { get; set; }
        [Display(Name = "")]
        public virtual ICollection<Persons> Persons { get; set; }
        [Display(Name = "")]
        public virtual ICollection<RolesAssignedToUsers> RolesAssignedToUsers { get; set; }
    }
}
