using Microsoft.AspNetCore.Mvc;
using Portfolio.DataContext;
using Portfolio.Entitys;
using Portfolio.Misc.Services.EmailSender;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers;

public class ContactsController : Controller
{
    private IEmailService EmailSender;

    private ApplicationContext _ApplicationContext;
    
    public ContactsController(IEmailService _emailSender, ApplicationContext _applicationContext)
    {
        EmailSender = _emailSender;
        _ApplicationContext = _applicationContext;
    }
    // GET
    [HttpGet]
    public IActionResult Contacts()
    {
        return View();
    }

    [HttpPost]
    public  IActionResult Contacts([FromForm] User userData)
    {
        _ApplicationContext.Requests.Add(new Request
        {
            RequestId = Guid.NewGuid(),
            Email = userData.Email,
            Name = userData.Name,
            Subject = userData.Subject,
            Message = userData.Message,
        });
        _ApplicationContext.SaveChanges();
        
        var message = new Message(new string[] { "japanlover1337@gmail.com" }, "Users Data",
                $"Email:{userData.Email}\nName:{userData.Name}\nSubject:{userData.Subject}\nMessage:\n{userData.Message}");
            EmailSender.SendEmailAsync(message);
            return Ok();
    }
}