using MVCexamenComics.Repositories;
using MVCexamenComics.Data;
using Microsoft.EntityFrameworkCore;
using Amazon.S3;
using MVCexamenComics.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<RepositoryComics>();
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddTransient<ServiceStorageS3>();
builder.Services.AddDbContext<ComicsContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Comics}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
