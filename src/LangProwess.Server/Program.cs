using System.Reflection;
using LangProwess.Web.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
	app.UseWebAssemblyDebugging();
else
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackWithApi();

app.Run();
