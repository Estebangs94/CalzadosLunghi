using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;

namespace CalzadosLunghi.Pages.TipoMateriales
{
    public class CreateModel : PageModel
    {
        private readonly ITipoMaterialData _tipoMaterialData;

        public CreateModel(ITipoMaterialData tipoMaterialData)
        {
            _tipoMaterialData = tipoMaterialData;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TipoMaterial TipoMaterial { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _tipoMaterialData.Add(TipoMaterial);
            await _tipoMaterialData.Commit();

            TempData["Message"] = "Se ha creado el siguiente tipo de material!";

            return RedirectToPage("./Details", new {id = result.ID});
        }
    }
}
