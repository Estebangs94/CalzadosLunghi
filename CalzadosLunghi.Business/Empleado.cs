using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Entities
{
    public class Empleado
    {
        public Empleado()
        {
            EstaActivo = true;
        }

        public int Id { get; set; }
        public bool EstaActivo { get; set; }
    }
}
