using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.Infrastructure.Data;
using SurveyApp.Infrastructure.Repository;
using SurveyApp.Services;
using SurveyMVC.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "server",
                        ValidAudience = "client",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SurveySecretWord"))
                    };
                });



if (connectionString != null)
{
    builder.Services.AddInjections(connectionString);
}

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("allow", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod(); 
        builder.AllowAnyOrigin(); 
    });
});




var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

app.UseSession();

app.Use(async (context, next) =>
{
    var JWToken = context.Session.GetString("JWTToken");
    if (!string.IsNullOrEmpty(JWToken))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
    }
    await next();
});
app.UseAuthentication();


app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
