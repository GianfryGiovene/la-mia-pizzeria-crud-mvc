using LaMiaPizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.Data
{
    public class PizzaContext :DbContext
    {
        public DbSet<Pizza> PizzaList { get; set; }
        public DbSet<Ingrediente> IngredienteList { get; set; }
        public DbSet<Categoria> CategoriaList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=pizza_db;Integrated Security=True");
        }

    }
}
