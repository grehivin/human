using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace bend.dal.entities
{
    public partial class UserCourses
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID Persona")]
        public int UserId { get; set; }
        [Display(Name = "ID Curso")]
        public int CourseId { get; set; }
        [Display(Name = "¿Completado?")]
        public bool Completed { get; set; }
        [Display(Name = "¿Aprobado?")]
        public bool Approved { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Users User { get; set; }

        public UserCourses()
        {
            Id = 0;
            UserId = 0;
            CourseId = 0;
            Completed = false;
            Approved = false;
        }

        public UserCourses(int personId, int courseId, bool completed, bool approved)
        {
            UserId = personId;
            CourseId = courseId;
            Completed = completed;
            Approved = approved;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string uid = "    \"IDUsuario\": " + UserId + ",\n";
            string cid = "    \"IDCurso\": " + CourseId + ",\n";
            string completed = "    \"¿Completado?\": " + Completed + ",\n";
            string approved = "    \"¿Aprobado?\": " + Approved + ",\n";

            return "CursosPorUsuario \n{\n" + id + uid + cid + completed + approved + "}";
        }
    }
}
