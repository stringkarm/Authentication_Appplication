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
    public class IndexModel : PageModel
    {
        private readonly Authentication_Appplication.Data.ApplicationDbContext _context;

        public IndexModel(Authentication_Appplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<HeelInfo> HeelInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            HeelInfo = await _context.HeelInfo.ToListAsync();
        }
    }
}
