using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Entities;
using CalzadosLunghi.Data;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalzadosLunghi.Pages.Materiales
{
    public class DetailsModel : PageModel
    {
        private readonly IMaterialData _materialData;

        public DetailsModel(IMaterialData materialData)
        {
            _materialData = materialData;
        }

        public Material Material { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = _materialData.GetById(id);

            if (Material == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}