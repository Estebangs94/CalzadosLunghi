using System;
using System.Collections.Generic;
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
        public TipoMaterial TipoMaterial { get; set; }
        public Color Color { get; set; }
        public UnidadMedida UnidadDeMedida { get; set; }
        public bool EstaActivo { get; set; }
    }
}
