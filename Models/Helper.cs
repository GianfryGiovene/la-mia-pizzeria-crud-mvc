
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaMiaPizzeria.Models
{
    public class Helper
    {
        public Pizza Pizza { set; get; }
        public List<Categoria>? CategoryList { get; set; }

        public List<SelectListItem>? IngredientiList { get; set; }
        public List<string>? SelectedIngredienti { get; set; }       
    }  
}

