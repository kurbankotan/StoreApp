using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext:DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options)
    {

    }


    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Many to Many ilişkisini tanımlamak için bir Şema ekleyelim
        modelBuilder.Entity<Product>()
                                      .HasMany(e=>e.Categories) 
                                      .WithMany(e=>e.Products)
                                      .UsingEntity<ProductCategory>();


        // Category'nin Url alanı bir index'e sahip olsun yani tekil (unique) olsun
        modelBuilder.Entity<Category>()
        .HasIndex(u=>u.Url)
        .IsUnique();


        //Test verileri eklenir

        modelBuilder.Entity<Product>().HasData(
            new List<Product>() {
                new () {Id=1, Name="Samsung S24", Price=40000, Description = "Samusungun en iyi telefonu"},
                new () {Id=2, Name="Samsung S25", Price=50000, Description = "Samusungun en iyi telefonu"},
                new () {Id=3, Name="Samsung S26", Price=60000, Description = "Samusungun en iyi telefonu"},
                new () {Id=4, Name="Samsung S27", Price=70000, Description = "Samusungun en iyi telefonu"},
                new () {Id=5, Name="Samsung S28", Price=80000, Description = "Samusungun en iyi telefonu"},
                new () {Id=6, Name="Samsung S29", Price=90000, Description = "Samusungun en iyi telefonu"},
                new () {Id=7, Name="Bosch Buzdolabı", Price=30000, Description = "Bosch'un en kaliteli Buzdolabı"}
            }
        );



        modelBuilder.Entity<Category>().HasData(
            new List<Category>() {
                new () {Id=1, Name="Telefon", Url = "telefon"},
                new () {Id=2, Name="Elektronik", Url = "elektronik"},
                new () {Id=3, Name="Beyaz Eşya", Url = "beyaz-esya"}          //extension method, slug dotnet ile kullanıcı "Beyaz Eşya" yazarsa "beyaz-esya" haline getirilebilir
            }
        );






    modelBuilder.Entity<ProductCategory>().HasData(
                                                    new List<ProductCategory>() {
                                                                                    new ProductCategory(){ProductId = 1, CategoryId=1},
                                                                                    new ProductCategory(){ProductId = 1, CategoryId=2}, // Hem Kategori 1 hem de Kategori 2
                                                                                    new ProductCategory(){ProductId = 2, CategoryId=1},
                                                                                    new ProductCategory(){ProductId = 3, CategoryId=1},
                                                                                    new ProductCategory(){ProductId = 4, CategoryId=1},
                                                                                    new ProductCategory(){ProductId = 5, CategoryId=2},
                                                                                    new ProductCategory(){ProductId = 6, CategoryId=2},
                                                                                    new ProductCategory(){ProductId = 7, CategoryId=3},
                                                                                }
                                                );










    }


}