using SurveyApp.Infrastructure.Data;
using SurveyApp.Infrastructure.Repository;
using SurveyApp.Services;
using SurveyMVC.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("db");
if (connectionString != null)
{
    builder.Services.AddInjections(connectionString);
}

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("allow", builder =>
    {
        builder.AllowAnyHeader(); //Her requeste izin ver.
        builder.AllowAnyMethod(); //Her metoda izin ver.
        builder.AllowAnyOrigin(); //Origin: http://wwww.turkcell.com.tr bir origindir, https://wwww.turkcell.com.tr bu bir öncekinden farklý bir origindir.
                                  //http://prpfile.turkcell.com.tr bu da farklý bir sub-origindir. http://wwww.turkcell.com.tr:8080 bu da farklý bir origindir.
                                  //Ama http://wwww.turkcell.com.tr/iletisim üstteki ile ayný origindir.
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SurveyDbContext>();
context.Database.EnsureCreated();
DbSeeding.SeedDatabase(context);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
