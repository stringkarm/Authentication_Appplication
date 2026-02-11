using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Authentication_Appplication.Data;
using Authentication_Appplication.Model;

namespace Authentication_Appplication.Pages.Register
{
    public class DeleteModel : PageModel
    {
        private readonly Authentication_Appplication.Data.ApplicationDbContext _context;

        public DeleteModel(Authentication_Appplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (users == null)
            {
                return NotFound();
            }
            else
            {
                Users = users;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                Users = users;
                _context.Users.Remove(Users);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
