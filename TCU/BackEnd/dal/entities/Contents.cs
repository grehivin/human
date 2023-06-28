using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dal.entities
{
    public partial class Contents
    {
        public Contents()
        {
            ContentOptions = new HashSet<ContentOptions>();
        }

        [Display(Name = "")]
        public int Id { get; set; }
        [Display(Name = "")]
        public int? TopicId { get; set; }
        [Display(Name = "")]
        public string ContentType { get; set; }
        [Display(Name = "")]
        public string Content { get; set; }
        [Display(Name = "")]
        public bool? Enabled { get; set; }

        [Display(Name = "")]
        public virtual Topics Topic { get; set; }
        [Display(Name = "")]
        public virtual ICollection<ContentOptions> ContentOptions { get; set; }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string tid = "    \"IDTema\": " + TopicId + ",\n";
            string contenttype = "    \"TipoContenido\": " + ContentType + ",\n";
            string content = "    \"Habilitada\": " + Content + ",\n";
            string enabled = "    \"Valida\": " + Enabled + ",\n";

            return "Opciones \n {" + id + tid + contenttype + content + enabled + "}";
        }
    }
}
