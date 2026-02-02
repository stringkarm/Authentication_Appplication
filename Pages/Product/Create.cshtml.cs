using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Authentication_Appplication.Data;
using Authentication_Appplication.Model;

namespace Authentication_Appplication.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly Authentication_Appplication.Data.ApplicationDbContext _context;

        public CreateModel(Authentication_Appplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HeelInfo HeelInfo { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HeelInfo.Add(HeelInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
