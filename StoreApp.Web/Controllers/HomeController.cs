using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Web.Models;

public class HomeController:Controller
{
    public ActionResult Index()              // public ActionResult Index() => View(); şeklinde de tanımlanabilir eğer parantez istenmiyorsa
    {
        return View();
    }
}