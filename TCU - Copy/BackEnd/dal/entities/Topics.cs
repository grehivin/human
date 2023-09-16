using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace bend.dal.entities
{
    public partial class Topics
    {
        [Display(Name = "ID Tema")]
        public int Id { get; set; }
        [Display(Name = "ID Curso")]
        public int CourseId { get; set; }
        [Display(Name = "Tema")]
        public string Topic { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        /*
        [Display(Name = "Curso")]
        public virtual Courses Course { get; set; } // */
        [Display(Name = "Contenido")]
        public virtual ICollection<Contents> Contents { get; set; }

        public Topics()
        {
            Id = 0;
            CourseId = 0;
            Topic = string.Empty;
            Enabled = false;
            // Course = new Courses();
            Contents = new HashSet<Contents>();
        }

        public Topics(int courseId, string topic, bool enabled, /* Courses course, */ ICollection<Contents> contents)
        {
            CourseId = courseId;
            Topic = topic;
            Enabled = enabled;
            // Course = course;
            Contents = contents;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string cid = "    \"IDCurso\": " + CourseId + ",\n";
            string subject = "    \"Tema\": " + Topic + ",\n";
            string enabled = "    \"¿Habilitado?\": " + Enabled + "\n";

            return "Tema \n{\n" + id + cid + subject + enabled + "}";
        }
    }
}
