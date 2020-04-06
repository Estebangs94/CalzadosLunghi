using System.ComponentModel.DataAnnotations;

namespace CalzadosLunghi.Business
{
    public class ParteZapato
    {
        public ParteZapato()
        {
            EstaActivo = true;
        }

        public int ID { get; set; }

        [Display(Name = "Componente")]
        [Required(ErrorMessage = "El campo 'Componente' es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Formado por más de un material")]
        public bool FormadoPorMultipleMateriales { get; set; }

        public string FormadoPorMultipleMaterialesString
        {
            get
            {
                if (FormadoPorMultipleMateriales == true)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }

        public bool EstaActivo { get; set; }
    }
}