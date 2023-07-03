using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dnu
{
    public partial class Courses
    {
        public Courses()
        {
            PersonCourses = new HashSet<PersonCourses>();
            Topics = new HashSet<Topics>();
        }

        public int Id { get; set; }
        public string Course { get; set; }
        public string Descr { get; set; }
        public bool? Enabled { get; set; }

        public virtual ICollection<PersonCourses> PersonCourses { get; set; }
        public virtual ICollection<Topics> Topics { get; set; }
    }
}
