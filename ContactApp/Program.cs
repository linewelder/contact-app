using ContactApp;
using DataLayer.Data;
using InfrastructureLayer;
using InfrastructureLayer.Email.Dtos;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<SmtpClientOptions>()
    .BindConfiguration(SmtpClientOptions.ConfigurationSectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();

var pages = builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment()) pages.AddRazorRuntimeCompilation();

var connectionString = builder.Configuration.GetConnectionString("Default")
                       ?? throw new InvalidOperationException("Connection string 'Default' not found");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.RegisterInfrastructureLayerDi();
builder.Services.RegisterServiceLayerDi();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    await app.SetupDatabaseAsync();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
