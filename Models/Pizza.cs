﻿using LaMiaPizzeria.Validators;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Campo obbligatorio")]
        [NegativePriceValidationAttribute]
        public double price;

        public int? CategoryId { get; set; }
        public Categoria? Category { set; get;  }


        public List<Ingrediente>? IngredienteList { get; set; }


        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                double roundedValue = Math.Round(value,2);
                price = roundedValue;
            }
        }
        
        public Pizza(string name, string description, string photoUrl, double price)
        {
            Name = name;
            Description = description;
            PhotoUrl = photoUrl;
            price = price;
        }

        public Pizza()
        {

        }

        //public void SetIngredienti(Ingrediente ingrediente1, Ingrediente ingrediente2, Ingrediente ingrediente3)
        //{
        //    IngredienteList.Add(ingrediente1);
        //    IngredienteList.Add(ingrediente2);
        //    IngredienteList.Add(ingrediente3);
        //}

        //public void SetIngredienti(Ingrediente ingrediente1, Ingrediente ingrediente2)
        //{
        //    IngredienteList.Add(ingrediente1);
        //    IngredienteList.Add(ingrediente2);
        //}

        //public void SetIngredienti(Ingrediente ingrediente1)
        //{
        //    IngredienteList.Add(ingrediente1);
        //}

    }
}
