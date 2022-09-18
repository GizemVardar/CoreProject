using Demo.Core.Business.Abstract;
using Demo.Core.Entities.Concrete;
using Demo.Core.MvcUI.Models;
using Demo.Core.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.MvcUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionServices _cartSessionServices;
        private IProductService _productService;
        private ICartService _cartService;
        public CartController(ICartSessionServices cartSessionServices, IProductService productService, ICartService cartService)
        {
            _cartSessionServices = cartSessionServices;
            _productService = productService;
            _cartService = cartService;
        }

        public IActionResult AddToCart(int productID)
        {
            var productAdded= _productService.GetByID(productID); // DB'de böyle bir ürün var mı diye kontrol yapılır.
            var cart = _cartSessionServices.GetCart();
            _cartService.AddToCart(cart,productAdded);
            _cartSessionServices.SetCart(cart);
            TempData.Add("message", string.Format("Your product,{0} , was successfully added to the cart!", productAdded.ProductName));
            return RedirectToAction("Index","Product");
        }

        //Burada sepete eklenen ürünleri list edeceğiz.
        public IActionResult List()
        {
            var cart = _cartSessionServices.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }

        public IActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetailsViewModel shippingDetailsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", string.Format("Thank you {0}, your order is in proccess", shippingDetailsViewModel.ShippingDetails.FirstName));
            return View();
        }

        // Complete ve Remove adında iki Action oluşturulcaktır.

        public IActionResult Remove(int productID)
        {
            var cart = _cartSessionServices.GetCart();
            _cartService.RemoveToCart(cart, productID);
            TempData.Add("message", string.Format("Your product was successfully removed from the cart!"));
            return RedirectToAction("List");
        }
    }
}
