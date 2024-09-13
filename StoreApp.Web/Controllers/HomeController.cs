using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class HomeController:Controller
{
    public int pageSize = 3; //Sayfa başına kaç ürün gelsin?
    private readonly IStoreRepository _storeRepository;

    private readonly IMapper _mapper;

    public HomeController(IStoreRepository storeRepository, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }


    //locahost:7000/?page=1
    public ActionResult Index(string category, int page =1)              // public ActionResult Index() => View(_storeRepository.Products); şeklinde de tanımlanabilir eğer parantez istenmiyorsa
    {


        return View(new ProductListViewModel{
            Products = _storeRepository
                                    .GetProductsByCategory(category, page, pageSize)
                                    .Select(product => _mapper.Map<ProductViewModel>(product)),
            PageInfo = new PageInfo{
                ItemsPerPage = pageSize,
                CurrentPage = page,
                TotalItems = _storeRepository.GetProductCount(category)
            }   
        });

    }










}