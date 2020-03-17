using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalzadosLunghi.Pages.Materiales
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Edit { get; set; }
        [TempData]
        public string Delete { get; set; }

        public void OnGet()
        {

        }
    }
}