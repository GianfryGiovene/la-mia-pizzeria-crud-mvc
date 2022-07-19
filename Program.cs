using LaMiaPizzeria.Data;
using LaMiaPizzeria.Models;

var builder = WebApplication.CreateBuilder(args);

//using (PizzaContext db = new PizzaContext())
//{
//    db.Add(new Ingrediente("Salsa"));
//    db.Add(new Ingrediente("Salame"));
//    db.Add(new Ingrediente("Mozzarella"));
//    db.Add(new Ingrediente("Peperoni"));
//    db.Add(new Ingrediente("Zucchine"));
//    db.Add(new Ingrediente("Salsiccia"));
//    db.Add(new Ingrediente("Cicogna"));
//    db.Add(new Ingrediente("Vasellina"));
//    db.SaveChanges();
//}
//using (PizzaContext db = new PizzaContext())
//{
//    List<Ingrediente> ingredienteList = db.IngredienteList.ToList<Ingrediente>();
//    List<Pizza> pizzaList = db.PizzaList.ToList<Pizza>();

//    pizzaList[0].SetIngredienti(ingredienteList[0], ingredienteList[2]);
//    pizzaList[1].SetIngredienti(ingredienteList[0], ingredienteList[2], ingredienteList[1]);
//    pizzaList[2].SetIngredienti(ingredienteList[4], ingredienteList[3], ingredienteList[3]);
//    pizzaList[3].SetIngredienti(ingredienteList[6], ingredienteList[7]);
//    db.SaveChanges();

//}


    // Add services to the container.
    builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();




var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
