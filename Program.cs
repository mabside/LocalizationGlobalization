using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(
    opt => {
        opt.ResourcesPath = "Resources";
});
builder.Services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>( opt => 
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en"),
        new CultureInfo("es"),
        new CultureInfo("fr"),
    };
    opt.DefaultRequestCulture = new RequestCulture("en");
    opt.SupportedCultures = supportedCultures;
    opt.SupportedUICultures = supportedCultures;
});

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

// var supportedCultures = new[] {"en", "fr", "es"};
// var localizationOptions = new RequestLocalizationOptions()
// .SetDefaultCulture(supportedCultures[1])
// .AddSupportedCultures(supportedCultures)
// .AddSupportedUICultures(supportedCultures);

// app.UseRequestLocalization(localizationOptions);

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
