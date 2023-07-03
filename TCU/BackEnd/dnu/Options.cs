using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dnu
{
    public partial class Options
    {
        public int Id { get; set; }
        public int? ContentId { get; set; }
        public string Descr { get; set; }
        public bool? Enabled { get; set; }
        public bool? Valid { get; set; }

        public virtual Contents Content { get; set; }
    }
}
