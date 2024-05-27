using InternetProdavnica.Data;
using InternetProdavnica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuration for EMail service
var emailConfig = builder.Configuration.GetSection("EmailConfiguration")
    .Get<EMailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddScoped<IEmailSender, EmailSender>();

//Dependecy injection with SQL connection
builder.Services.AddDbContext<InternetProdavnicaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequiredUniqueChars = 0;
    option.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<InternetProdavnicaContext>();

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

//asp-route-id - tag helper uz pomoc kog mozemo da prebacuje npr id trenutno gledanog objekta.
// Takodje mozemo da odradimo bind i to tako sto parametar u akciji kontrolera postavimo npr roleID. Time postavljamo
// asp-rout-roleID. Time smo bindovali ta dva polja i sad taj parametar moze da se prebaci u akciju kontrolera!
