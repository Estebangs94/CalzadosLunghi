using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;

namespace CalzadosLunghi.Pages.ParteZapatos
{
    public class DeleteModel : PageModel
    {
        private readonly CalzadosLunghi.Data.CalzadosLunghiDbContext _context;

        public DeleteModel(CalzadosLunghi.Data.CalzadosLunghiDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParteZapato = await _context.ParteZapatos.FindAsync(id);

            if (ParteZapato != null)
            {
                _context.ParteZapatos.Remove(ParteZapato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
