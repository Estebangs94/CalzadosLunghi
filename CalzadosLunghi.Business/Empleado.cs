using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Business
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
