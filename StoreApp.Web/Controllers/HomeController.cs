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
    public ActionResult Index()              // public ActionResult Index() => View(); şeklinde de tanımlanabilir eğer parantez istenmiyorsa
    {
        return View();
    }
}