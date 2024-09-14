using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Jogos.Data;
using Jogos.Models;
using Microsoft.EntityFrameworkCore;
using Jogos.ViewModels;

namespace Jogos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        HomeVM home = new()
        {
            Generos = _context.Generos.ToList(),
            Jogos = _context.Jogos
            .Include(j => j.Generos)
            .ThenInclude(pt => pt.Genero)
            .Include(j => j.Empresa)
            .ToList()
        };
        return View(home);
    }

    public IActionResult Details(int id)
    {
        Jogo jogo = _context.Jogos
            .Where(j => j.Id == id)
            .Include(j => j.Generos)
            .ThenInclude(pt => pt.Genero)
            .Include(j => j.Empresa)
            .SingleOrDefault();
        DetailsVM details = new()
        {
            Atual = jogo,
            Anterior = _context.Jogos
                .OrderByDescending(j => j.Id)
                .FirstOrDefault(j => j.Id < id),
            Proximo = _context.Jogos 
                .OrderBy(p => p.Id)
                .FirstOrDefault(j => j.Id > id),
        };
        return View(details);
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
