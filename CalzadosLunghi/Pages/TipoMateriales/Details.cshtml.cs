using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;

namespace CalzadosLunghi.Pages.TipoMateriales
{
    public class DetailsModel : PageModel
    {
        private readonly ITipoMaterialData _tipoMaterialData;

        public DetailsModel(ITipoMaterialData tipoMaterialData)
        {
            _tipoMaterialData = tipoMaterialData;
        }

        public TipoMaterial TipoMaterial { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoMaterial = _tipoMaterialData.GetById(id);

            if (TipoMaterial == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
