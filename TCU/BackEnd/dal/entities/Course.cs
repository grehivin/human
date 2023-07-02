using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class Course
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Curso")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Descr { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        [Display(Name = "Temas")]
        public virtual ICollection<Topic> Topics { get; set; }
        public Course()
        {
            Id = 0;
            Name = string.Empty;
            Descr = string.Empty;
            Enabled = false;
            Topics = new HashSet<Topic>();
        }

        public Course(string name, string descr, bool enabled, ICollection<Topic> topics)
        {
            Name = name;
            Descr = descr;
            Enabled = enabled;
            Topics = topics;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string name = "    \"IDPersona\": " + Name + ",\n";
            string descr = "    \"IDCurso\": " + Descr + ",\n";
            string enabled = "    \"¿Completado?\": " + Enabled + ",\n";

            return "CursosPorPersona \n{\n" + id + name + descr + enabled + "}";
        }
    }
}
