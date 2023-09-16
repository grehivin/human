using System.ComponentModel.DataAnnotations;

namespace bend.dal.entities
{
    public partial class UserContents
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID de usuario")]
        public int UserId { get; set; }
        [Display(Name = "ID de contenido")]
        public int ContentId { get; set; }
        [Display(Name = "¿Completado?")]
        public bool Completed { get; set; }

        [Display(Name = "Contenido por usuario")]
        public virtual Contents Content { get; set; }
        /*
        [Display(Name = "Usuarios")]
        public virtual Users User { get; set; } // */

        public UserContents()
        {
            Id = 0;
            UserId = 0;
            ContentId = 0;
            Completed = false;
        }

        public UserContents(int id, int userId, int contentId, bool completed)
        {
            Id = id;
            UserId = userId;
            ContentId = contentId;
            Completed = completed;
        }

        public override string ToString()
        {
            string id = "    \"ID\": " + Id + ",\n";
            string uid = "    \"IDUsuario\": " + UserId + ",\n";
            string cid = "    \"IDContenido\": " + ContentId + ",\n";
            string completed = "    \"¿Completado?\": " + Completed + "\n";

            return "ContenidosPorUsuario \n{\n" + id + uid + cid + completed + "}";
        }
    }
}
