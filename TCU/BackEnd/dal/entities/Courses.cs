using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace bend.dal.entities
{
    public partial class Courses
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Curso")]
        public string Course { get; set; }
        [Display(Name = "Descripción")]
        public string Descr { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        [Display(Name = "Temas")]
        public virtual ICollection<Topics> Topics { get; set; }
        [Display(Name = "Cursos por Persona")]
        public virtual ICollection<UserCourses> PersonCourses { get; set; }


        public Courses()
        {
            Id = 0;
            Course = string.Empty;
            Descr = string.Empty;
            Enabled = false;
            Topics = new HashSet<Topics>();
        }

        public Courses(string name, string descr, bool enabled, ICollection<Topics> topics)
        {
            Course = name;
            Descr = descr;
            Enabled = enabled;
            Topics = topics;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string name = "    \"Curso\": " + Course + ",\n";
            string descr = "    \"Descripción\": " + Descr + ",\n";
            string enabled = "    \"¿Habilitado?\": " + Enabled + ",\n";

            return "Curso \n{\n" + id + name + descr + enabled + "\n}";
        }
    }
}
