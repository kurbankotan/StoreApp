using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
namespace StoreApp.Web.Models;

public class HomeController:Controller
{
    public int pageSize = 3; //Sayfa başına kaç ürün gelsin?
    private IStoreRepository _storeRepository;
    public HomeController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }


    //locahost:7000/?page=1
    public ActionResult Index(int page =1)              // public ActionResult Index() => View(_storeRepository.Products); şeklinde de tanımlanabilir eğer parantez istenmiyorsa
    {
        var products = _storeRepository
                         .Products
                         .Skip((page-1)*pageSize)                 // 1-1 =>0*3 = 0 hiç ötelemez. 2-1 => 1*3 => 3 tane ötelenir 2. sayfa için
                         .Select(p => new ProductViewModel{
                                                            Id = p.Id,
                                                            Name = p.Name,
                                                            Description = p.Description,
                                                            Price = p.Price        
                                                          }).Take(pageSize);

        return View(new ProductListViewModel{
            Products = products
        });



    }




}