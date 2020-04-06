using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;

namespace CalzadosLunghi.Pages.ParteZapatos
{
    public class EditModel : PageModel
    {
        private readonly CalzadosLunghi.Data.CalzadosLunghiDbContext _context;

        public EditModel(CalzadosLunghi.Data.CalzadosLunghiDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParteZapato ParteZapato { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParteZapato = await _context.ParteZapatos.FirstOrDefaultAsync(m => m.ID == id);

            if (ParteZapato == null)
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

            _context.Attach(ParteZapato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return RedirectToPage("./Index");
        }

        private bool ParteZapatoExists(int id)
        {
            return _context.ParteZapatos.Any(e => e.ID == id);
        }
    }
}
