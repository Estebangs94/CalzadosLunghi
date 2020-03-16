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
    public class DetailsModel : PageModel
    {
        private readonly CalzadosLunghi.Data.CalzadosLunghiDbContext _context;

        public DetailsModel(CalzadosLunghi.Data.CalzadosLunghiDbContext context)
        {
            _context = context;
        }

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
    }
}
