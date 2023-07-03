using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dnu
{
    public partial class Topics
    {
        public Topics()
        {
            Contents = new HashSet<Contents>();
        }

        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string Topic { get; set; }
        public bool? Enabled { get; set; }

        public virtual Courses Course { get; set; }
        public virtual ICollection<Contents> Contents { get; set; }
    }
}
