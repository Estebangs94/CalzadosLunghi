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
        private readonly CalzadosLunghi.Data.CalzadosLunghiDbContext _context;

        public DeleteModel(CalzadosLunghi.Data.CalzadosLunghiDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoMaterial TipoMaterial { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoMaterial = await _context.TipoMateriales.FirstOrDefaultAsync(m => m.ID == id);

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

            TipoMaterial = await _context.TipoMateriales.FindAsync(id);

            if (TipoMaterial != null)
            {
                _context.TipoMateriales.Remove(TipoMaterial);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
