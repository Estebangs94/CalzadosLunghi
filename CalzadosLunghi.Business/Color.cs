using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CalzadosLunghi.Entities
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
        [Display(Name = "Color")]
        [Required(ErrorMessage ="El campo color es requerido")]
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
