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
    public class DeleteModel : PageModel
    {
        private readonly ITipoMaterialData _tipoMaterialData;

        public DeleteModel(ITipoMaterialData tipoMaterialData)
        {
            _tipoMaterialData = tipoMaterialData;
        }

        [BindProperty]
        public TipoMaterial TipoMaterial { get; set; }

        public  IActionResult OnGet(int? id)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoMaterial = _tipoMaterialData.GetById(id);

            if (TipoMaterial != null)
            {
                _tipoMaterialData.Delete(TipoMaterial.ID);
                await _tipoMaterialData.Commit();
            }

            TempData["Message"] = $"Se ha eliminado el tipo de material: {TipoMaterial.Nombre}!";

            return RedirectToPage("./Index");
        }
    }
}
