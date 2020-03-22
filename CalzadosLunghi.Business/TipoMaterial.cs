using System.ComponentModel.DataAnnotations;

namespace CalzadosLunghi.Business
{
    public class TipoMaterial
    {
        public TipoMaterial()
        {
            EstaActivo = true;
        }

        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Codigo { get; set; }
        public bool EstaActivo { get; set; }
    }
}