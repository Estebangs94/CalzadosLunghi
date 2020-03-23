using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CalzadosLunghi.Business
{
    public class Material
    {
        public Material()
        {
            Colores = new List<Color>();
            EstaActivo = true;
        }

        public enum UnidadMedida
        {
            Metro,
            Litro,
            Kilo,
            Unidad
        }

        public int ID { get; set; }
        public int TipoMaterialId { get; set; }
        public string Nombre { get; set; }
        [Display(Name ="Tipo de material")]
        public TipoMaterial TipoMaterial { get; set; }
        public List<Color> Colores { get; set; }
        [Display(Name = "Unidad de medida")]
        public UnidadMedida UnidadDeMedida { get; set; }
        public bool EstaActivo { get; set; }
        public List<ZapatoMaterial> ZapatoMateriales { get; set; }
    }
}
