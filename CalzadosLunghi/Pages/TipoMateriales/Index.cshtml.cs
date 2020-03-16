using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;

namespace CalzadosLunghi
{
    public class IndexModel : PageModel
    {
        private readonly ITipoMaterialData _tipoMaterialData;

        [TempData]
        public string Edit { get; set; }
        [TempData]
        public string Delete { get; set; }

        public IndexModel(ITipoMaterialData tipoMaterialData)
        {
            _tipoMaterialData = tipoMaterialData;
        }
      
        public IEnumerable<TipoMaterial> TipoMaterial { get;set; }
        public TipoMaterial Tipo { get; set; }

        public void OnGet()
        {
            TipoMaterial = _tipoMaterialData.GetAll();
        }
    }
}
