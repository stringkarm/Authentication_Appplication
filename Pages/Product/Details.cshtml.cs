using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Authentication_Appplication.Data;
using Authentication_Appplication.Model;

namespace Authentication_Appplication.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly Authentication_Appplication.Data.ApplicationDbContext _context;

        public DetailsModel(Authentication_Appplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public HeelInfo HeelInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heelinfo = await _context.HeelInfo.FirstOrDefaultAsync(m => m.VariantId == id);
            if (heelinfo == null)
            {
                return NotFound();
            }
            else
            {
                HeelInfo = heelinfo;
            }
            return Page();
        }
    }
}
