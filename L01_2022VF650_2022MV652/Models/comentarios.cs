using System.ComponentModel.DataAnnotations;

namespace L01_2022VF650_2022MV652.Models
{
    public class comentarios
    {
        [Key]
        public int comentariosId { get; set; }
        public int publicacionId { get; set; }
        public string comentario { get; set; }
        public int usuarioId { get; set; }
    }
}
