using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dal.entities
{
    public partial class ContentOptions
    {
        [Display(Name = "ID Opción")]
        public int Id { get; set; }
        [Display(Name = "ID Contenido")]
        public int? ContentId { get; set; }
        [Display(Name = "Decripción de la opción")]
        public string Descr { get; set; }
        [Display(Name = "¿Habilitada?")]
        public bool? Enabled { get; set; }
        [Display(Name = "¿Válida?")]
        public bool? Valid { get; set; }

        [Display(Name = "Pregunta")]
        public virtual Contents Content { get; set; }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string cid = "    \"IDPregunta\": " + ContentId + ",\n";
            string desc = "    \"Descripcion\": " + Descr +",\n";
            string enabled = "    \"Habilitada\": " + Enabled +",\n";
            string valid = "    \"Valida\": " + Valid +",\n";

            return "Opciones \n {" + id + cid + desc + enabled + valid + "}";
        }
    }
}
