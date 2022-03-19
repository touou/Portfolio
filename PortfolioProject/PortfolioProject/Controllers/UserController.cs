using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DataContext;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers;

[Authorize]
public class UserController : Controller
{
    
    private ApplicationContext _context;
    
    
    public UserController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult UserInfo()
    {
        return View();
    }
}