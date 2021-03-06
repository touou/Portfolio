using Microsoft.EntityFrameworkCore;
using Portfolio.DataContext;
using Portfolio.Misc.Services.EmailSender;
using Microsoft.AspNetCore.Identity;
using Portfolio.Entitys;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton(builder.Configuration.
    GetSection("EmailConfiguration").Get<EmailConfiguration>());

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddDbContext<ApplicationContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddControllersWithViews();



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();