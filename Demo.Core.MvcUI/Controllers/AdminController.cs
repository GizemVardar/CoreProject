using Demo.Core.Business.Abstract;
using Demo.Core.Entities.Concrete;
using Demo.Core.MvcUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.MvcUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        //GET: AdminController
        public ActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }
        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Products = new Products(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
            //Burada kategrileri list ediyoruz.
        }
        [HttpPost]
        public ActionResult Add(Products products)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(products);
                TempData.Add("message", "Product has been sucessfully added.");
            }
            return RedirectToAction("Add");
        }
    }
}