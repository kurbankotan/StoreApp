using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
namespace StoreApp.Web.Models;

public class HomeController:Controller
{
    private IStoreRepository _storeRepository;
    public HomeController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    public ActionResult Index()              // public ActionResult Index() => View(_storeRepository.Products); şeklinde de tanımlanabilir eğer parantez istenmiyorsa
    {
        var products = _storeRepository.Products.Select(p => new ProductViewModel{
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price        }).ToList();

        return View(new ProductListViewModel{
            Products = products
        });
    }




}