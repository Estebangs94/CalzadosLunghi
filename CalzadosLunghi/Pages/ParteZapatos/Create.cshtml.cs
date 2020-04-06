using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;
using CalzadosLunghi.Data.Interfaces;

namespace CalzadosLunghi.Pages.ParteZapatos
{
    public class CreateModel : PageModel
    {
        private readonly IParteZapatoData _parteZapatoData;

        [BindProperty]
        public ParteZapato ParteZapato { get; set; }

        public CreateModel(IParteZapatoData parteZapatoData)
        {
            _parteZapatoData = parteZapatoData;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _parteZapatoData.Add(ParteZapato);
            await _parteZapatoData.Commit();

            TempData["Message"] = "Se ha creado un nuevo componente de zapato";

            return RedirectToPage("./Details", new { id = result.ID });
        }
    }
}
