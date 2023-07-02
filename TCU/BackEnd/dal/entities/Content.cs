using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class Content
    {
        [Display(Name = "ID Contenido")]
        public int Id { get; set; }
        [Display(Name = "ID Tema")]
        public int TopicId { get; set; }
        [Display(Name = "Tipo de contenido")]
        public string ContentType { get; set; }
        [Display(Name = "Contenido")]
        public string Descr { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        [Display(Name = "Tema")]
        public virtual Topic Topic { get; set; }
        [Display(Name = "Opciones")]
        public virtual ICollection<ContentOption> ContentOptions { get; set; }

        public Content()
        {
            Id = 0;
            TopicId = 0;
            ContentType = string.Empty;
            Descr = string.Empty;
            Enabled = false;
            Topic = new Topic();
            ContentOptions = new HashSet<ContentOption>();
        }

        public Content(int tid, string contentType, string descr, bool enabled, Topic topic)
        {
            TopicId = tid;
            ContentType = contentType;
            Descr = descr;
            Enabled = enabled;
            Topic = topic;
            ContentOptions = new HashSet<ContentOption>();
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string tid = "    \"IDTema\": " + TopicId + ",\n";
            string ct = "    \"TipoContenido\": " + ContentType + ",\n";
            string descr = "    \"Habilitada\": " + Descr + ",\n";
            string enabled = "    \"Valida\": " + Enabled + ",\n";

            return "Contenido \n{\n" + id + tid + ct + descr + enabled + "}";
        }
    }
}
