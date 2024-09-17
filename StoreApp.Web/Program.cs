using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Web.Models;

var builder = WebApplication.CreateBuilder(args);

//Controllers'larla Views'leri ilişikeldirdiği bir yapı kullanacağımıza dair servisi ekleyelim
builder.Services.AddControllersWithViews();

//RazorPages'ları llanacağımıza dair servisi ekleyelim
builder.Services.AddRazorPages();

// AutoMapper servisi ekle
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<StoreDbContext>(options => {
    options.UseSqlite(builder.Configuration["ConnectionStrings:StoreDbConnection"], b => b.MigrationsAssembly("StoreApp.Web"));
});



builder.Services.AddScoped<IStoreRepository,EFStoreRepository>();


//Önce build edelim
var app = builder.Build();

//Build ettikten sonra statik dosyaları kullanıcağız
app.UseStaticFiles();

//products/telefon        => O kategorideki Ürün Listesi
app.MapControllerRoute("products_in_category", "products/{category?}", new {controller="Home", action ="Index"});


//samsung-s25             => ürün detay
app.MapControllerRoute("product_details", "{name}", new {controller="Home", action ="Details"});


//Default Route Şeması eklensin
app.MapDefaultControllerRoute();   //Controller'in adı, View ve Id şeklinde

//Razorpages için de Route'ini ekleyelim ki yönlendirme yapsın
app.MapRazorPages();

app.Run();
