using LaMiaPizzeria.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]        
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(100, ErrorMessage = "La lunghezza di {0} dev'essere compresa tra {2} e {1}.", MinimumLength = 5)]
        [MoreThanFiveWordValidationAttribute]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Url(ErrorMessage = "L'url inserito non è nel formato corretto")]
        public string PhotoUrl { get; set; }

        [Required(ErrorMessage = "Jola")]
        [NegativePriceValidationAttribute]        
        public double Price { get; set; }

        public List<Ingrediente>? IngredienteList { get; set; }

        
        public Pizza(string name, string description, string photoUrl, double price)
        {
            Name = name;
            Description = description;
            PhotoUrl = photoUrl;
            Price = price;
        }

        public Pizza()
        {

        }

        public void SetIngredienti(Ingrediente ingrediente1, Ingrediente ingrediente2, Ingrediente ingrediente3)
        {
            IngredienteList.Add(ingrediente1);
            IngredienteList.Add(ingrediente2);
            IngredienteList.Add(ingrediente3);
        }

        public void SetIngredienti(Ingrediente ingrediente1, Ingrediente ingrediente2)
        {
            IngredienteList.Add(ingrediente1);
            IngredienteList.Add(ingrediente2);
        }

        public void SetIngredienti(Ingrediente ingrediente1)
        {
            IngredienteList.Add(ingrediente1);
        }

    }
}
