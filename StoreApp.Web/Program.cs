using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

//Controllers'larla Views'leri ilişikeldirdiği bir yapı kullanacağımıza dair servisi ekleyelim
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<StoreDbContext>(options => {
    options.UseSqlite(builder.Configuration["ConnectionStrings:StoreDbConnection"], b => b.MigrationsAssembly("StoreApp.Web"));
});



builder.Services.AddScoped<IStoreRepository,EFStoreRepository>();


//Önce build edelim
var app = builder.Build();

//Build ettikten sonra statik dosyaları kullanıcağız
app.UseStaticFiles();

//Default Route Şeması eklensin
app.MapDefaultControllerRoute();   //Controller'in adı, View ve Id şeklinde

app.Run();
