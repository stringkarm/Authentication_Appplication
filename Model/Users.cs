using System.ComponentModel.DataAnnotations;

namespace Authentication_Appplication.Model
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
    }
}