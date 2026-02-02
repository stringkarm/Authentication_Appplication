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

namespace Authentication_Appplication.Pages.Heels
{
    public class EditModel : PageModel
    {
        private readonly Authentication_Appplication.Data.ApplicationDbContext _context;

        public EditModel(Authentication_Appplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Heel Heel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heel =  await _context.Heel.FirstOrDefaultAsync(m => m.HeelId == id);
            if (heel == null)
            {
                return NotFound();
            }
            Heel = heel;
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

            _context.Attach(Heel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeelExists(Heel.HeelId))
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

        private bool HeelExists(int id)
        {
            return _context.Heel.Any(e => e.HeelId == id);
        }
    }
}
