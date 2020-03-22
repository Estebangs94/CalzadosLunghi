namespace CalzadosLunghi.Business
{
    public class ParteZapato
    {
        public ParteZapato()
        {
            EstaActivo = true;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool FormadoPorMultipleMateriales { get; set; }
        public bool EstaActivo { get; set; }
    }
}