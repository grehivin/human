using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd
{
    public partial class Contents
    {
        public Contents()
        {
            Options = new HashSet<Options>();
        }

        public int Id { get; set; }
        public int? TopicId { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public bool? Enabled { get; set; }

        public virtual Topics Topic { get; set; }
        public virtual ICollection<Options> Options { get; set; }
    }
}
