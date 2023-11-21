#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cocineros_y_Platos.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cocineros_y_Platos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Chefs()
    {
        List<Chef> ListaChefs = _context.Chefs.Include(c => c.PlatosCreados).ToList();
        ViewBag.AllChefs = ListaChefs;
        return View("Chefs");
    }

    [HttpGet("platos")]
    public IActionResult Platos()
    {
        List<Plato> ListaPlatos = _context.Platos.Include(p => p.Creador).ToList();
        ViewBag.AllPlatos = ListaPlatos;
        return View("Platos");
    }

    [HttpGet("New")]
    public IActionResult AgregarChef()
    {
        return View("AgregarChef");
    }

    [HttpPost("CrearChef")]
    public IActionResult CrearChef(Chef NuevoChef)
    {
        Console.WriteLine(ModelState.IsValid);
        if (ModelState.IsValid)
        {
            _context.Add(NuevoChef);
            _context.SaveChanges();
            return RedirectToAction("Chefs");
        }
        else
        {
            foreach (var key in ModelState.Keys)
            {
                var errors = ModelState[key]?.Errors;
                if (errors != null)
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
            }

            return View("AgregarChef");
        }
    }

    [HttpGet("platos/New")]
    public IActionResult AgregarPlato()
    {
        List<Chef> ListaChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = ListaChefs;
        return View("AgregarPlato");
    }

    [HttpPost("CrearPlato")]
    public IActionResult CrearPlato(Plato NuevoPlato)
    {
        _context.Add(NuevoPlato);
        _context.SaveChanges();
        return RedirectToAction("Platos");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
