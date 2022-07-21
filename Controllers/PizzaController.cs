using LaMiaPizzeria.Data;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        //************* INDEX VIEW ***************
        [HttpGet]
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                IQueryable<Pizza> pizzaList = db.PizzaList.Include(p => p.Category);
                
                return View("Index", pizzaList.ToList());
            }
        }


        //************* DETAILS VIEW ***************

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {  
                Pizza pizza  = db.PizzaList.Where(p => p.Id == id).Include(c => c.Category).FirstOrDefault();

                if(pizza == null)
                {
                    return NotFound("Pizza non trovata");
                }
                else
                {
                    db.Entry(pizza).Collection("IngredienteList").Load();
                    
                    return View("Details", pizza);
                }
               
            }

        }

        //************* POST CREATE VIEW ***************
        [HttpPost]      
        [ValidateAntiForgeryToken]
        public IActionResult Create(Helper model)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new PizzaContext())
                {
                    List<Categoria> categoryList = db.CategoriaList.ToList();

                    model.CategoryList = categoryList;
                    model.IngredientiList = NewMethod();

                    return View("Create", model);
                }

            }
            using (PizzaContext db = new PizzaContext())
            {
                Pizza newPizza = new Pizza();
                newPizza.Name = model.Pizza.Name;
                newPizza.Description = model.Pizza.Description;
                newPizza.price = model.Pizza.Price;
                newPizza.PhotoUrl = model.Pizza.PhotoUrl;
                newPizza.CategoryId = model.Pizza.CategoryId;
                newPizza.IngredienteList = new List<Ingrediente>();

                if (model.SelectedIngredienti != null)
                {
                    foreach (string ingredient in model.SelectedIngredienti)
                    {
                        int selectedIntTagId = Int32.Parse(ingredient);

                        Ingrediente ingrediente = db.IngredienteList.Where(p => p.Id == selectedIntTagId).FirstOrDefault();

                        newPizza.IngredienteList.Add(ingrediente);
                    }
                }
                db.PizzaList.Add(newPizza);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }         

        //************* GET CREATE VIEW ***************
        [HttpGet]
        public IActionResult Create()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Categoria> categories = db.CategoriaList.ToList();
                Helper model = new Helper();

                model.Pizza = new Pizza();
                model.CategoryList = categories;

                model.IngredientiList = NewMethod();


                return View("Create",model);
            }
        }

        //************* GET UPDATE VIEW ***************
        [HttpGet]
        public IActionResult Update(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.PizzaList.Where(p => p.Id == id).FirstOrDefault();
                if(pizza == null)
                {
                    return NotFound();
                }  
                else
                {
                    Helper model = new Helper();

                    model.Pizza = pizza;
                    model.CategoryList = db.CategoriaList.ToList();

                    return View(model);
                }
            }
        }

        //************* POST UPDATE VIEW ***************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Helper p)
        {            
            using(PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
                {
                    p.CategoryList = db.CategoriaList.ToList();
                    return View(p);
                }

                Pizza editPizza = db.PizzaList.Where(p => p.Id == id).FirstOrDefault();

                if(editPizza == null)
                {
                    return NotFound();
                }

                editPizza.Name = p.Pizza.Name;
                editPizza.Description = p.Pizza.Description;
                editPizza.Price = p.Pizza.Price;
                editPizza.PhotoUrl = p.Pizza.PhotoUrl;
                editPizza.CategoryId = p.Pizza.CategoryId;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        //************* DELETE VIEW ***************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.PizzaList.Where(p => p.Id == id).FirstOrDefault();

                if(pizza == null)
                {
                    return NotFound();
                }
                else
                {
                    db.PizzaList.Remove(pizza);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
        }
        static List<SelectListItem> NewMethod()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<SelectListItem> ingredientsList = new List<SelectListItem>();
                List<Ingrediente> ingredients = db.IngredienteList.ToList();

                foreach (Ingrediente ingredient in ingredients)
                {
                    ingredientsList.Add(new SelectListItem() { Text = ingredient.Name, Value = ingredient.Id.ToString() });
                }

                return ingredientsList;
            }
        }

    }
}
