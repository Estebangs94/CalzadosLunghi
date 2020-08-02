using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Entities;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CalzadosLunghi.Pages.Materiales.Colores
{
    public class EditModel : PageModel
    {
        private readonly IColorData _colorData;
        [BindProperty]
        public Color Color { get; set; }
        [BindProperty]
        public int MaterialId { get; set; }

        public EditModel(IColorData colorData)
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
            MaterialId = Color.Material.ID;

            if (Color == null)
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

            Color.EstaActivo = true;
            Color.MaterialId = MaterialId;
            _colorData.Update(Color);

            try
            {
                await _colorData.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(Color.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["Edit"] = $"Se ha editado el color: {Color.Nombre}";

            return RedirectToPage("/Materiales/Colores/Index", new { materialId = MaterialId});
        }

        private bool ColorExists(int id)
        {
            var result = _colorData.GetById(id);
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