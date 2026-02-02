using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Authentication_Appplication.Data;
using Authentication_Appplication.Model;

namespace Authentication_Appplication.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly Authentication_Appplication.Data.ApplicationDbContext _context;

        public EditModel(Authentication_Appplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HeelInfo HeelInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heelinfo =  await _context.HeelInfo.FirstOrDefaultAsync(m => m.VariantId == id);
            if (heelinfo == null)
            {
                return NotFound();
            }
            HeelInfo = heelinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HeelInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeelInfoExists(HeelInfo.VariantId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HeelInfoExists(int id)
        {
            return _context.HeelInfo.Any(e => e.VariantId == id);
        }
    }
}
