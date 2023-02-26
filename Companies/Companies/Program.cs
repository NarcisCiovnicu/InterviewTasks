using Companies.BusinessLogic.Services;
using Companies.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
RegisterServices(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();



static void RegisterServices(IServiceCollection services)
{
    services.AddSingleton<ICompanyService, CompanyService>();

    services.AddSingleton<ICompanyRepository, CompanyFileRepository>();
}