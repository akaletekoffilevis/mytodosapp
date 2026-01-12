using Microsoft.EntityFrameworkCore;
using TodosApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TodoContext>(opt =>
 opt.UseSqlite(
    builder.Configuration.GetConnectionString("TodoDatabase")
 )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Todo/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute
(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}"
).WithStaticAssets();


app.Run();
