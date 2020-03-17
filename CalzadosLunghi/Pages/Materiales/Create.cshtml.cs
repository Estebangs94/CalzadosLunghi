using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Business;
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
        private readonly IColorData _colorData;

        [BindProperty]
        public Material Material { get; set; }
        public IEnumerable<SelectListItem> UnidadDeMedida { get; set; }
        public SelectList Colores { get; set; }

        public CreateModel(IHtmlHelper htmlHelper, IMaterialData materialData, IColorData colorData)
        {
            _htmlHelper = htmlHelper;
            _materialData = materialData;
            _colorData = colorData;
        }

        public IActionResult OnGet()
        {
            CargarUnidadesMedida();
            CargarColores();

            return Page();
        }

        private void CargarColores()
        {
            var todos = _colorData.GetAll();
            Colores = new SelectList(todos, "ID", "Nombre");
        }

        public async Task<IActionResult> OnPostAsync()
        {


            return RedirectToPage("./Index");
        }

        private void CargarUnidadesMedida()
        {
            UnidadDeMedida = _htmlHelper.GetEnumSelectList<UnidadMedida>();
        }
    }
}