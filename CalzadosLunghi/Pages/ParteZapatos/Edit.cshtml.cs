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

namespace CalzadosLunghi.Pages.ParteZapatos
{
    public class EditModel : PageModel
    {
        private readonly IParteZapatoData _parteZapatoData;

        public EditModel(IParteZapatoData parteZapatoData)
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

            ParteZapato = _parteZapatoData.GetById(id.Value);

            if (ParteZapato == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ParteZapato.EstaActivo = true;
            var result = _parteZapatoData.Update(ParteZapato);

            try
            {
                await _parteZapatoData.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParteZapatoExists(ParteZapato.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["Edit"] = $"Se ha editado el componente: {ParteZapato.Nombre}";

            return RedirectToPage("./Index");
        }

        private bool ParteZapatoExists(int id)
        {
            var result = _parteZapatoData.GetById(id);
            if (result != null)
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
