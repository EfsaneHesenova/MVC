using Microsoft.AspNetCore.Mvc;

namespace MVCtask2.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Pricing()
    {
        return View();
    }
    
    public IActionResult Work()
    {
        return View();
    }
    
    public IActionResult Work_single()
    {
        return View();
    }
    
    public IActionResult Contact()
    {
        return View();
    }
    
}