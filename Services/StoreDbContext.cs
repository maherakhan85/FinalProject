using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
namespace FinalProject.Services
{
    public class StoreDbContext : DbContext
    { 
        public StoreDbContext(DbContextOptions options): base(options) 
        { }
       public DbSet<Employee> Employees { get; set; }   

    }
}