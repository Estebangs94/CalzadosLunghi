using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Entities;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalzadosLunghi.Pages.Materiales
{
    public class IndexModel : PageModel
    {
        private readonly IMaterialData _materialData;

        [TempData]
        public string Edit { get; set; }
        [TempData]
        public string Delete { get; set; }
        public IndexModel(IMaterialData materialData)
        {
            _materialData = materialData;
        }

        public Material Material { get; set; }
        public IEnumerable<Material> Materiales { get; set; }

        public void OnGet()
        {
            Materiales = _materialData.GetAll();
        }
    }
}