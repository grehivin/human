using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dnu
{
    public partial class Persons
    {
        public Persons()
        {
            PersonCourses = new HashSet<PersonCourses>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PersonCourses> PersonCourses { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
