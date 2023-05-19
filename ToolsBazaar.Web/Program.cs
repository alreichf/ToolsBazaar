using Microsoft.AspNetCore.Localization;
using System.Globalization;
using ToolsBazaar.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.AddLocalization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

var requestCulture = new RequestCulture("en-GB");
requestCulture.Culture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
app.UseRequestLocalization(new RequestLocalizationOptions
                           {
                               DefaultRequestCulture = requestCulture,
                           });

app.MapControllerRoute("default",
                       "{controller}/{action=Index}/{id?}");

app.Run();