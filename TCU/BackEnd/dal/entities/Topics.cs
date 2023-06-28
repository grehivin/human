using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dal.entities
{
    public partial class Topics
    {
        public Topics()
        {
            Contents = new HashSet<Contents>();
        }

        [Display(Name = "")]
        public int Id { get; set; }
        [Display(Name = "")]
        public int? CourseId { get; set; }
        [Display(Name = "")]
        public string Topic { get; set; }
        [Display(Name = "")]
        public bool? Enabled { get; set; }

        [Display(Name = "")]
        public virtual Courses Course { get; set; }
        [Display(Name = "")]
        public virtual ICollection<Contents> Contents { get; set; }
    }
}
