using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeria.Models
{
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pizza> PizzaList { get; set; }

        public Ingrediente(string name)
        {
            Name = name;            
        }

    }
}
