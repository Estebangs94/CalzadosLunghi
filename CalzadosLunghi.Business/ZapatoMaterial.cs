using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CalzadosLunghi.Entities
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
        [Display(Name = "Rendimiento")]
        public int CantidadZapatosPorUnidad { get; set; }
        public ParteZapato ParteZapato { get; set; }
        public bool EstaActivo { get; set; }
    }
}
