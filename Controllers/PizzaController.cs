using LaMiaPizzeria.Data;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(Helper p)
        {
            using(PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
                {
                    p.CategoryList = db.CategoriaList.ToList();

                    return View(p);
                }

                db.PizzaList.Add(p.Pizza);
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

                model.CategoryList = categories;
                model.Pizza = new Pizza();
                return View(model);
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
    }
}
