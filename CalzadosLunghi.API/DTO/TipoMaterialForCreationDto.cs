using System.ComponentModel.DataAnnotations;

namespace CalzadosLunghi.API.DTO
{
    public class TipoMaterialForCreationDto
    {
        public string Nombre { get; set; }
        [Required]
        public string Codigo { get; set; }
    }
}