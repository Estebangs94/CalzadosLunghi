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
    public class IndexModel : PageModel
    {
        private readonly IMaterialData _materialData;
        private readonly IColorData _colorData;

        public int MaterialId { get; set; }

        [TempData]
        public string Edit { get; set; }

        [TempData]
        public string Delete { get; set; }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public IEnumerable<Color> ColoresMaterial { get; set; }
        public Material Material { get; set; }
        public Color Color { get; set; }

        public IndexModel(IMaterialData materialData, IColorData colorData)
        {
            _materialData = materialData;
            _colorData = colorData;
        }

        public IActionResult OnGet(int materialId)
        {
            MaterialId = materialId;
            Material = _materialData.GetById(materialId);

            if(Material == null)
            {
                return NotFound();
            }

            ColoresMaterial = _colorData.GetAllByMaterialId(materialId);

            return Page();
        }
    }
}