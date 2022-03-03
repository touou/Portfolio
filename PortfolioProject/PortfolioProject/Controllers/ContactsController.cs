using Microsoft.AspNetCore.Mvc;
using Portfolio.Misc.Services.EmailSender;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers;

public class ContactsController : Controller
{
    private IEmailService EmailSender;
    
    public ContactsController(IEmailService _emailSender)
    {
        EmailSender = _emailSender;
    }
    // GET
    [HttpGet]
    public IActionResult Contacts()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contacts([FromForm] User userData)
    {
        
            var message = new Message(new string[] { "japanlover1337@gmail.com" }, "Users Data",
                $"Email:{userData.Email}\nName:{userData.Name}\nSubject:{userData.Subject}\nMessage:\n{userData.Message}");
            await EmailSender.SendEmailAsync(message);
            return Ok();

    }
}