using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static CalzadosLunghi.Business.Material;

namespace CalzadosLunghi.Pages.Materiales
{
    public class CreateModel : PageModel
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly IMaterialData _materialData;
        private readonly ITipoMaterialData _tipoMaterialData;

        [BindProperty]
        public Material Material { get; set; }
        public IEnumerable<SelectListItem> UnidadDeMedida { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> TipoDeMateriales { get; set; }

        public CreateModel(IHtmlHelper htmlHelper, IMaterialData materialData, ITipoMaterialData tipoMaterialData)
        {
            _htmlHelper = htmlHelper;
            _materialData = materialData;
            _tipoMaterialData = tipoMaterialData;
        }

        public IActionResult OnGet()
        {
            CargarUnidadesMedida();
            CargarTipoDeMateriales();

            return Page();
        }

        private void CargarTipoDeMateriales()
        {
            var datos = _tipoMaterialData.GetAll();

            TipoDeMateriales = new SelectList(datos, "ID", "Nombre");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = _materialData.Add(Material);

            await _materialData.Commit();

            TempData["Message"] = "Se ha creado un nuevo material";

            return RedirectToPage("./Details", new { id = result.ID });
        }

        private void CargarUnidadesMedida()
        {
            UnidadDeMedida = _htmlHelper.GetEnumSelectList<UnidadMedida>();
        }
    }
}