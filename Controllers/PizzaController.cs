﻿using LaMiaPizzeria.Data;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzaList = db.PizzaList.OrderBy(pizza => pizza.Id).ToList<Pizza>();

                if(pizzaList == null)
                {
                    return NotFound("Pizze non presenti");
                }
                return View(pizzaList);
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {  
                Pizza pizza  = db.PizzaList.Where(pizza => pizza.Id == id).FirstOrDefault();

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
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pizza);
            }
            using (PizzaContext db = new PizzaContext())
            {
                db.PizzaList.Add(pizza);
                db.SaveChanges();

            }
           

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
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
                    return View(pizza);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            using(PizzaContext db = new PizzaContext())
            {
                Pizza editPizza = db.PizzaList.Where(p => p.Id == id).FirstOrDefault();

                if(editPizza == null)
                {
                    return NotFound();
                }

                editPizza.Name = pizza.Name;
                editPizza.Description = pizza.Description;
                editPizza.Price = pizza.Price;
                editPizza.PhotoUrl = pizza.PhotoUrl;

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
