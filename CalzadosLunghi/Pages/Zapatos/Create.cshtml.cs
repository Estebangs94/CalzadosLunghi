using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalzadosLunghi.Pages.Zapatos
{
    public class CreateModel : PageModel
    {
        private readonly IParteZapatoData _parteZapatoData;
        public IEnumerable<ParteZapato> ListaParteZapatos { get; set; }
        public SelectList<Material> MaterialesSelectList { get; set; }
        public Material MyProperty { get; set; }

        public CreateModel(IParteZapatoData parteZapatoData)
        {
            _parteZapatoData = parteZapatoData;
        }

        public IActionResult OnGet()
        {
            ListaParteZapatos = _parteZapatoData.GetAll();

            for (int i = 0; i < ListaParteZapatos.Count(); i++)
            {
                //crear 1 select list por ZapatoParte

            }

            return Page();
        }
    }
}