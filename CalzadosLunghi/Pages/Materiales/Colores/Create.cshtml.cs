using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Entities;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalzadosLunghi.Pages.Materiales.Colores
{
    public class CreateModel : PageModel
    {
        private readonly IMaterialData _materialData;
        private readonly IColorData _colorData;

        public Material Material { get; set; }

        [BindProperty]
        public int MaterialId { get; set; }

        [BindProperty]
        public Color Color { get; set; }

        public CreateModel(IMaterialData materialData, IColorData colorData)
        {
            _materialData = materialData;
            _colorData = colorData;
        }

        public IActionResult OnGet(int materialId)
        {
            MaterialId = materialId;
            CargarMaterial(materialId);

            if (Material == null)
            {
                return NotFound();
            }

            return Page();
        }

        private void CargarMaterial(int materialId)
        {
            Material = _materialData.GetById(materialId);
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                CargarMaterial(MaterialId);
                return Page();
            }

            Color.MaterialId = MaterialId;
            var result = _colorData.Add(Color);
            await _colorData.Commit();
            TempData["Message"] = $"Se ha creado el color: {result.Nombre}";

            return RedirectToPage("/Materiales/Colores/Index", new { materialId = MaterialId });
        }
    }
}