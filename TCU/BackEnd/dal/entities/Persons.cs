using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dal.entities
{
    public partial class Persons
    {
        public Persons()
        {
            CoursesByPerson = new HashSet<CoursesByPerson>();
            Users = new HashSet<Users>();
        }

        [Display(Name = "")]
        public int Id { get; set; }
        [Display(Name = "")]
        public string Name { get; set; }
        [Display(Name = "")]
        public string Lastname { get; set; }
        [Display(Name = "")]
        public string Email { get; set; }
        [Display(Name = "")]
        public int? UserId { get; set; }

        [Display(Name = "")]
        public virtual Users User { get; set; }
        [Display(Name = "")]
        public virtual ICollection<CoursesByPerson> CoursesByPerson { get; set; }
        [Display(Name = "")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
