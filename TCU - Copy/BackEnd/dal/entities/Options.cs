using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bend.dal.entities
{
    public partial class Options
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

        /*
        [Display(Name = "Pregunta")]
        public virtual Contents Content { get; set; }
        [Display(Name = "Respuestas por usuario")]
        public virtual ICollection<UserResponses> UserResponses { get; set; } // */

        public Options()
        {
            Id = 0;
            ContentId = 0;
            Descr = string.Empty;
            Enabled = false; 
            Valid = false;
            // Content = new Contents();
        }

        public Options(int cid, string desc) //, Contents content)
        {
            ContentId = cid;
            Descr = desc;
            Enabled = false;
            Valid = false;
            // Content = content;
        }

        public Options(int id, int cid, string desc, bool enabled, bool valid) //, Contents content)
        {
            Id = id;
            ContentId = cid;
            Descr = desc;
            Enabled = enabled;
            Valid = valid;
            // Content = content;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string cid = "    \"IDContenido\": " + ContentId + ",\n";
            string desc = "    \"Descripción\": " + Descr +",\n";
            string enabled = "    \"¿Habilitada?\": " + Enabled +",\n";
            string valid = "    \"¿Valida?\": " + Valid +"\n";

            return "Opcion \n{\n" + id + cid + desc + enabled + valid + "}";
        }
    }
}
