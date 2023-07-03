using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dnu
{
    public partial class PersonCourses
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? CourseId { get; set; }
        public bool? Completed { get; set; }
        public bool? Approved { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Persons Person { get; set; }
    }
}
