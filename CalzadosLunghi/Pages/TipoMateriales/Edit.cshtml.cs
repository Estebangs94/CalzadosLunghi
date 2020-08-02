using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalzadosLunghi.Entities;
using CalzadosLunghi.Data;
using CalzadosLunghi.Data.Interfaces;

namespace CalzadosLunghi.Pages.TipoMateriales
{
    public class EditModel : PageModel
    {
        private readonly ITipoMaterialData _tipoMaterialData;

        public EditModel(ITipoMaterialData tipoMaterialData)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TipoMaterial.EstaActivo = true;
            _tipoMaterialData.Update(TipoMaterial);

            try
            {
                await _tipoMaterialData.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMaterialExists(TipoMaterial.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["Edit"] = $"Se ha editado el tipo de material: {TipoMaterial.Nombre}";

            return RedirectToPage("./Index");
        }

        private bool TipoMaterialExists(int id)
        {
            var result = _tipoMaterialData.GetById(id);
            if(result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
