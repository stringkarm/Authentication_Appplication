using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Authentication_Appplication.Data;
using Authentication_Appplication.Model;

namespace Authentication_Appplication.Pages.Heels
{
    public class DetailsModel : PageModel
    {
        private readonly Authentication_Appplication.Data.ApplicationDbContext _context;

        public DetailsModel(Authentication_Appplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Heel Heel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heel = await _context.Heel.FirstOrDefaultAsync(m => m.HeelId == id);
            if (heel == null)
            {
                return NotFound();
            }
            else
            {
                Heel = heel;
            }
            return Page();
        }
    }
}
