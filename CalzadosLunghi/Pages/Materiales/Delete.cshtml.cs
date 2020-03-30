using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalzadosLunghi.Pages.Materiales
{
    public class DeleteModel : PageModel
    {
        private readonly IMaterialData _materialData;
        public string Delete { get; set; }
        public string Message { get; set; }

        [BindProperty]
        public Material Material { get; set; }

        public DeleteModel(IMaterialData materialData)
        {
            _materialData = materialData;
        }

        public IActionResult OnGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Material = _materialData.GetById(id);
            if(Material == null)
            {
                return NotFound();
            }

            if(Material.Colores.Count > 0)
            {
                if (Material.Colores.Count == 1)
                {
                    Delete = $"Éste material tiene asociado un color";
                }
                else
                {
                    Delete = $"Éste material tiene asociado {Material.Colores.Count} colores";
                }
            }
            else
            {
                Message = "Éste material no tiene asociado ningún color";
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Material = _materialData.GetById(id);
            if(Material == null)
            {
                return NotFound();
            }

            _materialData.Delete(Material.ID);
            await _materialData.Commit();

            TempData["Delete"] = $"Se ha eliminado el material: {Material.Nombre}";

            return RedirectToPage("./Index");
        }
    }
}