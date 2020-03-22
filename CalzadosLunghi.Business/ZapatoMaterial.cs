using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Business
{
    public class ZapatoMaterial
    {
        public ZapatoMaterial()
        {
            EstaActivo = true;
        }

        public int ZapatoId { get; set; }
        public int MaterialId { get; set; }
        public int ParteZapatoId { get; set; }
        public Zapato Zapato { get; set; }
        public Material Material { get; set; }
        public int CantidadZapatosPorUnidad { get; set; }
        public ParteZapato ParteZapato { get; set; }
        public bool EstaActivo { get; set; }
    }
}
