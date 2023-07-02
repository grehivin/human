using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BackEnd.dal.entities
{
    public partial class CoursesByPerson
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID Persona")]
        public int PersonId { get; set; }
        [Display(Name = "ID Curso")]
        public int CourseId { get; set; }
        [Display(Name = "¿Completado?")]
        public bool Completed { get; set; }
        [Display(Name = "¿Aprobado?")]
        public bool Approved { get; set; }

        public CoursesByPerson()
        {
            Id = 0;
            PersonId = 0;
            CourseId = 0;
            Completed = false;
            Approved = false;
        }

        public CoursesByPerson(int personId, int courseId, bool completed, bool approved)
        {
            PersonId = personId;
            CourseId = courseId;
            Completed = completed;
            Approved = approved;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string pid = "    \"IDPersona\": " + PersonId + ",\n";
            string cid = "    \"IDCurso\": " + CourseId + ",\n";
            string completed = "    \"¿Completado?\": " + Completed + ",\n";
            string approved = "    \"¿Aprobado?\": " + Approved + ",\n";

            return "CursosPorPersona \n{\n" + id + pid + cid + completed + approved + "}";
        }
    }
}
