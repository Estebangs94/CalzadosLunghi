using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Entities
{
    public class Zapato
    {
        public Zapato()
        {
            EstaActivo = true;
        }

        public int ID { get; set; }
        public int TemporadaId { get; set; }
        public Temporada Temporada { get; set; }
        public List<ZapatoMaterial> ListaZapatoMateriales { get; set; }
        public bool EstaActivo { get; set; }
    }
}
