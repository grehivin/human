using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class Topic
    {
        [Display(Name = "ID Tema")]
        public int Id { get; set; }
        [Display(Name = "ID Curso")]
        public int CourseId { get; set; }
        [Display(Name = "Tema")]
        public string Subject { get; set; }
        [Display(Name = "¿Habilitado?")]
        public bool Enabled { get; set; }

        [Display(Name = "Curso")]
        public virtual Course Course { get; set; }
        [Display(Name = "Contenido")]
        public virtual ICollection<Content> Contents { get; set; }

        public Topic()
        {
            Id = 0;
            CourseId = 0;
            Subject = string.Empty;
            Enabled = false;
            Course = new Course();
            Contents = new HashSet<Content>();
        }

        public Topic(int courseId, string subject, bool enabled, Course course, ICollection<Content> contents)
        {
            CourseId = courseId;
            Subject = subject;
            Enabled = enabled;
            Course = course;
            Contents = contents;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string cid = "    \"IDCurso\": " + CourseId + ",\n";
            string subject = "    \"Tema\": " + Subject + ",\n";
            string enabled = "    \"¿Habilitado?\": " + Enabled + ",\n";

            return "Tema \n{\n" + id + cid + subject + enabled + "}";
        }
    }
}
