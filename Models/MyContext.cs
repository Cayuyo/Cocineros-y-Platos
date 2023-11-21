#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Cocineros_y_Platos.Models;

public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Plato> Platos {get;set;}
    }