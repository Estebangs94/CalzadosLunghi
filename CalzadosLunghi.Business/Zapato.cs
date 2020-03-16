using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Business
{
    public class Zapato
    {
        public int ID { get; set; }
        public Temporada Temporada { get; set; }
        public IEnumerable<Material> Capellada { get; set; }
        public Material ForroCapellada { get; set; }
        public Material ForroPlantilla { get; set; }
        public Material Puntera { get; set; }
        public Material ContraFuerte { get; set; }
    }
}
