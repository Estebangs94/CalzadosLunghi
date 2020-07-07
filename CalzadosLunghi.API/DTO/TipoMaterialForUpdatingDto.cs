using System.ComponentModel.DataAnnotations;

namespace CalzadosLunghi.API.DTO
{
    /// <summary>
    ///Clase que sirve para obtener los datos de una request 
    ///de un tipo de material a actualizar   
    /// </summary>


    public class TipoMaterialForUpdatingDto
    {
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Codigo { get; set; }
        public bool EstaActivo { get; set; }
    }
}