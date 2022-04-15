using System.Dynamic;
using Microsoft.AspNetCore.Authentication.Cookies;
using MySqlConnector;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SCPOS.Services;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEntryService, EntryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserClaimProvider, UserClaimProvider>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x => x.LoginPath = "/account/login");

MySqlConnection connection = new MySqlConnection(
    builder.Configuration.GetConnectionString("myDb1")
);

QueryFactory db = new(connection, new MySqlCompiler());

builder.Services.AddSingleton(db);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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