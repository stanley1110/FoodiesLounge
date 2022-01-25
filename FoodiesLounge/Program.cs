
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using static FoodiesLoungeUtilities.EmailSender;
using System.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using FoodiesLoungeUtilities;
using FoodiesLoungeModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IShoppingCart, ShoppingCartRepo>();
builder.Services.AddScoped<IFoodTypeRepo, FoodTypeRepo>();
builder.Services.AddScoped<IMenuItemRepo, MenuItemRepo>();
builder.Services.AddScoped<IOrderView, OrderViewRepo>();
builder.Services.AddScoped<IOrderDetail,  OrderDetailRepo>();
builder.Services.AddScoped<IApplicationUser, ApplicationUserRepo>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.Configure<Paystack>(builder.Configuration.GetSection("Paystack"));
builder.Services.ConfigureApplicationCookie(
    options =>
    {
        options.LogoutPath = "/Identity/Account/Logout";
        options.LoginPath = "/Identity/Account/Login";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
