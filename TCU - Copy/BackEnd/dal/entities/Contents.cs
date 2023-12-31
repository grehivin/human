﻿using System.ComponentModel.DataAnnotations;

namespace bend.dal.entities
{
    public partial class Contents
    {
        [Display(Name = "ID Contenido")]
        public int Id { get; set; }
        [Display(Name = "ID Tema")]
        public int TopicId { get; set; }
        [Display(Name = "Tipo de contenido")]
        public string ContentType { get; set; }
        [Display(Name = "Contenido")]
        public string Content { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        /*
        [Display(Name = "Tema")]
        public virtual Topics Topic { get; set; } // */
        [Display(Name = "Opciones por contenido")]
        public virtual ICollection<Options> Options { get; set; }
        /*
        [Display(Name = "Contenido por usuario")]
        public virtual ICollection<UserContents> UserContents { get; set; }
        [Display(Name = "Respuestas por usuario")]
        public virtual ICollection<UserResponses> UserResponses { get; set; } // */

        public Contents()
        {
            Id = 0;
            TopicId = 0;
            ContentType = string.Empty;
            Content = string.Empty;
            Enabled = false;
            // Topic = new Topics();
            Options = new HashSet<Options>();
        }

        public Contents(int tid, string contentType, string descr, bool enabled, Topics topic)
        {
            TopicId = tid;
            ContentType = contentType;
            Content = descr;
            Enabled = enabled;
            // Topic = topic;
            Options = new HashSet<Options>();
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string tid = "    \"IDTema\": " + TopicId + ",\n";
            string ct = "    \"TipoContenido\": " + ContentType + ",\n";
            string descr = "    \"Descripción\": " + Content + ",\n";
            string enabled = "    \"Habilitado\": " + Enabled + "\n";

            return "Contenido \n{\n" + id + tid + ct + descr + enabled + "}";
        }
    }
}
