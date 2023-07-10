using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6.Models;

namespace TP6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
{
    
    ViewBag.Partidos = BD.ListarPartidos(); 
    return View();
}

public IActionResult VerDetallePartido(int idPartido)
{
    ViewBag.DatosPartido = BD.VerInfoPartido(idPartido);
    ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
    return View("VerDetallePartido");
}
public IActionResult VerDetalleCandidato(int idCandidato)
{   
    ViewBag.DatosCandidato = BD.VerInfoCandidato(idCandidato);
    return View("VerDetalleCandidato");
}
public IActionResult AgregarCandidato(int idPartido)
{   
 ViewBag.IdPartido = idPartido;
    return View("AgregarCandidato");
}


[HttpPost]
public IActionResult GuardarCandidato(Candidato can)
{
    BD.AgregarCandidato(can);
    ViewBag.DatosPartido = BD.VerInfoPartido(can.IdPartido);
    ViewBag.ListaCandidatos = BD.ListarCandidatos(can.IdPartido);
    return View("VerDetallePartido");
}


public IActionResult EliminarCandidato(int idCandidato, int idPartido)
{
    BD.EliminarCandidato(idCandidato);
    ViewBag.DatosPartido = BD.VerInfoPartido(idPartido);
    ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
    return View("VerDetallePartido");
}
public IActionResult Elecciones()
{
    return View("queSeVota");
}

public IActionResult Creditos()
{
    return View("Creditos");
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
