using Company.Data;
using Company.Repositories.Interface;
using Company.Repositories.Repository;
using Company.Services.Interface;
using Company.Services.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
builder.Services.AddScoped<IAkunRepository, AkunRepository>();
builder.Services.AddScoped<IAkunService, AkunService>();
builder.Services.AddScoped<IPenggunaService, PenggunaService>();
builder.Services.AddScoped<IPenggunaRepository, PenggunaRepository>();
builder.Services.AddScoped<IPeranAkunRepository, PeranAkunRepository>();
builder.Services.AddScoped<IPeranAkunService, PeranAkunService>();
builder.Services.AddScoped<IPenggunaKantorRepository, PenggunaKantorRepo>();
builder.Services.AddScoped<IPenggunaKantorService, PenggunaKantorService>();
builder.Services.AddScoped<ILayarRepo, LayarRepo>();
builder.Services.AddScoped<ILayarService, LayarService>();
builder.Services.AddScoped<ILayarAkunRepo, LayarAkunRepo>();
builder.Services.AddScoped<ILayarAkunService, LayarAkunService>();
builder.Services.AddScoped<IPeranRepo, PeranRepo>();
builder.Services.AddScoped<IPeranService, PeranService>();
builder.Services.AddScoped<IKantorRepo, KantorRepo>();
builder.Services.AddScoped<IKantorService, KantorService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Layar}/{action=DaftarAkun}/{id?}");

app.Run();
