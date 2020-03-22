﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Business
{
    public class Color
    {
        public Color()
        {
            EstaActivo = true;
        }

        public int ID { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
