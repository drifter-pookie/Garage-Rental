using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentalGarageSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register DatabaseHelper as a singleton service with the connection string.
builder.Services.AddSingleton<DatabaseHelper>(provider => new DatabaseHelper("Data Source=rentalgarage.db"));

var app = builder.Build();

// Ensure the database is initialized at startup.
using (var scope = app.Services.CreateScope())
{
    var dbHelper = scope.ServiceProvider.GetRequiredService<DatabaseHelper>();
    dbHelper.InitializeDatabase();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
