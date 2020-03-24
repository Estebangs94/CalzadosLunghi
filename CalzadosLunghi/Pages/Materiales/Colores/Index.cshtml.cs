using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalzadosLunghi.Pages.Materiales.Colores
{
    public class IndexModel : PageModel
    {
        private readonly IMaterialData _materialData;

        public int MaterialId { get; set; }

        public IndexModel(IMaterialData materialData)
        {
            _materialData = materialData;
        }

        public IActionResult OnGet(int materialId)
        {
            MaterialId = materialId;
            var material = _materialData.GetById(materialId);

            if(material == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}