
using Authentication_Appplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Authentication_Appplication.Pages

{
    public class LoginModel : PageModel
    {
        [BindProperty]      
        public Users Users { get; set; } = new Users();

        public IActionResult OnPost()
        {
            if(Users.Username == "admin" && Users.Password == "admin123" )
            {
                return RedirectToPage("/Index");
            }
           
            return Page();
        }
    }
}
