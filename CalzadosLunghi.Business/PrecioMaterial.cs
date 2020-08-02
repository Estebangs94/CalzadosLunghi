using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Entities
{
    public class PrecioMaterial
    {
        public PrecioMaterial()
        {
            EstaActivo = true;
        }

        public int ID { get; set; }
        public int MaterialId { get; set; }
        public DateTime FechaVigencia { get; set; }
        public DateTime? FechaFin { get; set; }
        public Material Material { get; set; }
        public bool EstaActivo { get; set; }
    }
}
