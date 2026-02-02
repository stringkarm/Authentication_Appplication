using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Authentication_Appplication.Model;

namespace Authentication_Appplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Authentication_Appplication.Model.HeelInfo> HeelInfo { get; set; } = default!;
        public DbSet<Authentication_Appplication.Model.Heel> Heel { get; set; } = default!;
    }
}
