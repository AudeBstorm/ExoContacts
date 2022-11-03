using ExoContacts.BLL.Services;
using ExoContacts.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

//Config pour pouvoir utiliser les variables de session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//Indiquer que notre app va utiliser les variables de session
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
