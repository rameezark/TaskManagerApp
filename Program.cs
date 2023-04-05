using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Extensions;
using TaskManagerApp.Mapper;
using TaskManagerApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TaskDbContext>(context => { 
    context.UseInMemoryDatabase("TaskDb"); 
    context.EnableSensitiveDataLogging(); 
});
builder.Services.AddDependentServices();
builder.Services.AddAutoMapper(typeof(ObjectMappings));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
