using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;
using CalzadosLunghi.Data.Interfaces;

namespace CalzadosLunghi.Pages.TipoMateriales
{
    public class DeleteModel : PageModel
    {
        private readonly ITipoMaterialData _tipoMaterialData;
        private readonly IMaterialData _materialData;

        [BindProperty]
        public TipoMaterial TipoMaterial { get; set; }

        public string Delete { get; set; }
        public string Message { get; set; }

        public DeleteModel(ITipoMaterialData tipoMaterialData, IMaterialData materialData)
        {
            _tipoMaterialData = tipoMaterialData;
            _materialData = materialData;
        }

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

            var materialesAsociados = _materialData.GetMaterialsForMaterialType(TipoMaterial.ID);
            if(materialesAsociados.Count() > 0)
            {
                Delete = $"Éste tipo de material tiene asociado {materialesAsociados.Count()} materiales";
            }
            else
            {
                Message = $"Éste tipo de material no tiene materiales asociados";
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

            TempData["Delete"] = $"Se ha eliminado el tipo de material: {TipoMaterial.Nombre}";

            return RedirectToPage("./Index");
        }
    }
}
