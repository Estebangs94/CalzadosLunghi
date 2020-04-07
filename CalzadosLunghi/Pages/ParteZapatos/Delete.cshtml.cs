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

namespace CalzadosLunghi.Pages.ParteZapatos
{
    public class DeleteModel : PageModel
    {
        private readonly IParteZapatoData _parteZapatoData;

        public DeleteModel(IParteZapatoData parteZapatoData)
        {
            _parteZapatoData = parteZapatoData;
        }

        [BindProperty]
        public ParteZapato ParteZapato { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParteZapato = _parteZapatoData.GetById(id);

            if (ParteZapato == null)
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

            ParteZapato = _parteZapatoData.GetById(id);

            if (ParteZapato != null)
            {
                var result = _parteZapatoData.Delete(ParteZapato.ID);
                await _parteZapatoData.Commit();
            }

            TempData["Delete"] = $"Se ha eliminado el componente: {ParteZapato.Nombre}";

            return RedirectToPage("./Index");
        }
    }
}
