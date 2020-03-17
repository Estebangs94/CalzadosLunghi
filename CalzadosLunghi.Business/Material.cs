using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CalzadosLunghi.Business
{
    public class Material
    {
        public enum UnidadMedida
        {
            Metro,
            Litro,
            Kilo,
            Unidad
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        [Display(Name ="Tipo de material")]
        public TipoMaterial TipoMaterial { get; set; }
        public Color Color { get; set; }
        [Display(Name = "Unidad de medida")]
        public UnidadMedida UnidadDeMedida { get; set; }
        public bool EstaActivo { get; set; }
    }
}
