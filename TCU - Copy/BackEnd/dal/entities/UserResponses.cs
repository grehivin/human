using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bend.dal.entities
{
    public partial class UserResponses
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID de usuario")]
        public int UserId { get; set; }
        [Display(Name = "ID de contenido")]
        public int ContentId { get; set; }
        [Display(Name = "ID de opción")]
        public int OptionId { get; set; }

        [Display(Name = "Contenido")]
        public virtual Contents Content { get; set; }
        [Display(Name = "Opción")]
        public virtual Options Option { get; set; }

        /*
        [Display(Name = "Usuario")]
        public virtual Users User { get; set; } // */

        public UserResponses()
        {
            Id = 0;
            UserId = 0;
            ContentId = 0;
            OptionId = 0;
        }

        public UserResponses(int id, int userId, int contentId, int optionId)
        {
            Id = id;
            UserId = userId;
            ContentId = contentId;
            OptionId = optionId;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string uid = "    \"IDUsuario\": " + UserId + ",\n";
            string cid = "    \"IDCurso\": " + ContentId + ",\n";
            string oid = "    \"¿Completado?\": " + OptionId + "\n";

            return "CursosPorUsuario \n{\n" + id + uid + cid + oid + "}";
        }
    }
}
