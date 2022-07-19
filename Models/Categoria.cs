using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models
{
    
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public List<Pizza> PizzaList { get; set; }


        public Categoria()
        {

        }
    }
}
