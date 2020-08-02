using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Entities;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalzadosLunghi.Pages.Zapatos
{
    public class CreateModel : PageModel
    {
        private readonly IParteZapatoData _parteZapatoData;
        private readonly IMaterialData _materialData;

        public IEnumerable<ParteZapato> ListaParteZapatos { get; set; }
        [BindProperty]
        public Material MaterialSeleccionado { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> MaterialesList { get; set; }
        public MultiSelectList MultMaterialsList { get; set; }

        [BindProperty]
        public IEnumerable<int> SelectedMaterials { get; set; }

        [BindProperty]
        public int[] selectedMaterials { get; set; }

        [BindProperty]
        public int SelectedMaterial { get; set; }

        public CreateModel(IParteZapatoData parteZapatoData, IMaterialData materialData)
        {
            _parteZapatoData = parteZapatoData;
            _materialData = materialData;
        }

        public IActionResult OnGet()
        {
            ListaParteZapatos = _parteZapatoData.GetAll();
            var materiales = _materialData.GetAll();
            MaterialesList = new SelectList(materiales, "ID", "Nombre");
            MultMaterialsList = new MultiSelectList(materiales, "ID", "Nombre");

            foreach (var item in ListaParteZapatos)
            {
                //crear 1 select list por ZapatoParte
                //usar multiselect list para los casos de que se puede seleccionar mas de 1 material (fucking big brain)
                if(item.FormadoPorMultipleMateriales)
                {

                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {


            return RedirectToPage("./Index");
            //return RedirectToPage("./Index", new { id = result.ID });
        }
    }
}