using System.Reflection;
using LangProwess.Server.Data;
using LangProwess.Web.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSystemd();

builder.Services.AddOptions();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

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
