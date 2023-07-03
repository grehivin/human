using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dnu
{
    public partial class Users
    {
        public Users()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public int? PersonId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Enabled { get; set; }

        public virtual Persons Person { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
