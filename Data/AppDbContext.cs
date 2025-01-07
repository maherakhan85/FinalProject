using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
