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
    public class IndexModel : PageModel
    {
        private readonly LLTM.MyAirport.EF.MyAirportContext _context;

        public IndexModel(LLTM.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCompany { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchDes { get; set; }

        public async Task OnGetAsync()
        { 
            var vols = from v in _context.Vols
                       select v;
            if (!string.IsNullOrEmpty(SearchCompany))
            {
                vols = vols.Where(s => s.Cie.Contains(SearchCompany));
            }
            if (!string.IsNullOrEmpty(SearchDes))
            {
                vols = vols.Where(s => s.Des.Contains(SearchDes));
            }

            Vol = await _context.Vols.ToListAsync();
        }
       
    }
}
