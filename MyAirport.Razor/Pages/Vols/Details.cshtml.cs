using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LLTM.MyAirport.EF;

namespace MyAirport.Razor.Pages.Vols
{
    public class DetailsModel : PageModel
    {
        private readonly LLTM.MyAirport.EF.MyAirportContext _context;

        public DetailsModel(LLTM.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public Vol Vol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vol = await _context.Vols.FirstOrDefaultAsync(m => m.VolID == id);

            if (Vol == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
