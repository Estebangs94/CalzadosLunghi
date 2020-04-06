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
    public class DetailsModel : PageModel
    {
        private readonly IParteZapatoData _parteZapatoData;

        public ParteZapato ParteZapato { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailsModel(IParteZapatoData parteZapatoData)
        {
            _parteZapatoData = parteZapatoData;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParteZapato = _parteZapatoData.GetById(id);

            if (ParteZapato == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
