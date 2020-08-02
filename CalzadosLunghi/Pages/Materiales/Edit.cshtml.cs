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
using static CalzadosLunghi.Entities.Material;

namespace CalzadosLunghi.Pages.Materiales
{
    public class EditModel : PageModel
    {
        private readonly IMaterialData _materialData;
        private readonly IHtmlHelper _htmlHelper;
        private readonly ITipoMaterialData _tipoMaterialData;

        [BindProperty]
        public Material Material { get; set; }
        public IEnumerable<SelectListItem> UnidadDeMedida { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> TipoDeMateriales { get; set; }

        public EditModel(IMaterialData materialData, IHtmlHelper htmlHelper, ITipoMaterialData tipoMaterialData)
        {
            _materialData = materialData;
            _htmlHelper = htmlHelper;
            _tipoMaterialData = tipoMaterialData;
        }

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

            CargarUnidadesMedida();
            CargarTipoDeMateriales();

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

            Material.EstaActivo = true;
            _materialData.Update(Material);

            try
            {
                await _materialData.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(Material.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["Edit"] = $"Se ha editado el material: {Material.Nombre}";

            return RedirectToPage("./Index");
        }

        private bool MaterialExists(int id)
        {
            var result = _materialData.GetById(id);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CargarTipoDeMateriales()
        {
            var datos = _tipoMaterialData.GetAll();

            TipoDeMateriales = new SelectList(datos, "ID", "Nombre");
        }

        private void CargarUnidadesMedida()
        {
            UnidadDeMedida = _htmlHelper.GetEnumSelectList<UnidadMedida>();
        }
    }
}