using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class HomeController:Controller
{
    public int pageSize = 3; //Sayfa başına kaç ürün gelsin?
    private IStoreRepository _storeRepository;
    public HomeController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }


    //locahost:7000/?page=1
    public ActionResult Index(string category, int page =1)              // public ActionResult Index() => View(_storeRepository.Products); şeklinde de tanımlanabilir eğer parantez istenmiyorsa
    {


        return View(new ProductListViewModel{
            Products = _storeRepository.GetProductsByCategory(category, page, pageSize).Select(p => new ProductViewModel{
                                                                Id = p.Id,
                                                                Name = p.Name,
                                                                Description = p.Description,
                                                                Price = p.Price        
                                                            }),
            PageInfo = new PageInfo{
                ItemsPerPage = pageSize,
                CurrentPage = page,
                TotalItems = _storeRepository.GetProductCount(category)
            }   
        });

    }










}