using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CalzadosLunghi.Business;
using CalzadosLunghi.Data;
using CalzadosLunghi.Data.Interfaces;

namespace CalzadosLunghi.Pages.ParteZapatos
{
    public class IndexModel : PageModel
    {
        private readonly IParteZapatoData _parteZapatoData;

        public IEnumerable<ParteZapato> ParteZapatos { get; set; }
        public ParteZapato ParteZapato { get; set; }

        [TempData]
        public string Edit { get; set; }
        [TempData]
        public string Delete { get; set; }

        public IndexModel(IParteZapatoData parteZapatoData)
        {
            _parteZapatoData = parteZapatoData;
        }

        public IActionResult OnGet()
        {
            ParteZapatos = _parteZapatoData.GetAll();

            return Page();
        }
    }
}
