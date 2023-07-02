using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.dal.entities
{
    public partial class ContentOption
    {
        [Display(Name = "ID Opción")]
        public int Id { get; set; }
        [Display(Name = "ID Contenido")]
        public int ContentId { get; set; }
        [Display(Name = "Decripción de la opción")]
        public string Descr { get; set; }
        [Display(Name = "¿Habilitada?")]
        public bool Enabled { get; set; }
        [Display(Name = "¿Válida?")]
        public bool Valid { get; set; }

        [Display(Name = "Pregunta")]
        public virtual Content Content { get; set; }

        public ContentOption()
        {
            Id = 0;
            ContentId = 0;
            Descr = string.Empty;
            Enabled = false; 
            Valid = false;
            Content = new Content();
        }

        public ContentOption(int cid, string desc, Content content)
        {
            ContentId = cid;
            Descr = desc;
            Enabled = false;
            Valid = false;
            Content = content;
        }

        public ContentOption(int id, int cid, string desc, bool enabled, bool valid, Content content)
        {
            Id = id;
            ContentId = cid;
            Descr = desc;
            Enabled = enabled;
            Valid = valid;
            Content = content;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string cid = "    \"IDPregunta\": " + ContentId + ",\n";
            string desc = "    \"Descripcion\": " + Descr +",\n";
            string enabled = "    \"Habilitada\": " + Enabled +",\n";
            string valid = "    \"Valida\": " + Valid +",\n";

            return "Opcion \n{\n" + id + cid + desc + enabled + valid + "}";
        }
    }
}
