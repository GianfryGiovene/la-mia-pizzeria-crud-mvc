﻿using LaMiaPizzeria.Data;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                IQueryable<Pizza> pizzaList = db.PizzaList.Include(p => p.Category);
                //List<Pizza> pizzaList = db.PizzaList.OrderBy(pizza => pizza.Id).ToList<Pizza>();

                //if(pizzaList == null)
                //{
                //    return NotFound("Pizze non presenti");
                //}
                return View("Index", pizzaList.ToList());
            }
        }

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategories p)
        {
            using(PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
                {
                    p.CategoryList = db.CategoriaList.ToList();

                    return View();
                }

                db.PizzaList.Add(p.Pizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Categoria> categories = db.CategoriaList.ToList();
                PizzaCategories model = new PizzaCategories();

                model.CategoryList = categories;
                model.Pizza = new Pizza();
                return View(model);
            }
        }

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
                    PizzaCategories model = new PizzaCategories();

                    model.Pizza = pizza;
                    model.CategoryList = db.CategoriaList.ToList();

                    return View(model);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaCategories p)
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
