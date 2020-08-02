using System.Collections.Generic;

namespace CalzadosLunghi.Entities
{
    public class Temporada
    {
        public Temporada()
        {
            Zapatos = new List<Zapato>();
            EstaActivo = true;
        }

        public enum Temporadas
        {
            Invierno,
            Verano
        }

        public int ID { get; set; }
        public List<Zapato> Zapatos { get; set; }
        public int Year { get; set; }
        public Temporadas TemporadaActual { get; set; }
        public bool EstaActivo { get; set; }
    }
}