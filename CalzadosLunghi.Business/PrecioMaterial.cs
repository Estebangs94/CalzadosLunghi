using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Business
{
    public class PrecioMaterial
    {
        public int ID { get; set; }
        public DateTime FechaVigencia { get; set; }
        public DateTime? FechaFin { get; set; }
        public Material Material { get; set; }
        public bool EstaActivo { get; set; }
    }
}
