using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalzadosLunghi.Pages.Materiales.Colores
{
    public class DeleteModel : PageModel
    {
        private readonly IColorData _colorData;

        [BindProperty]
        public Color Color { get; set; }
        public int MaterialId { get; set; }
        public DeleteModel(IColorData colorData)
        {
            _colorData = colorData;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = _colorData.GetById(id);
            if (Color == null)
            {
                return NotFound();
            }

            MaterialId = Color.Material.ID;

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = _colorData.GetById(id);
            if (Color == null)
            {
                return NotFound();
            }

            _colorData.Delete(Color.ID);
            await _colorData.Commit();

            TempData["Delete"] = $"Se ha eliminado el color: {Color.Nombre}";

            return RedirectToPage("/Materiales/Colores/Index", new { materialId = Color.Material.ID });
        }
    }
}