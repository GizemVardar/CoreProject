
using Demo.Core.MvcUI.Models;
using Demo.Core.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Demo.Core.MvcUI.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ICartSessionServices _cartSessionService;

        public CartSummaryViewComponent(ICartSessionServices cartSessionServices)
        {
            _cartSessionService= cartSessionServices;
        }

        //Sepete git dedigimizde burada sepeti goruntuleyecegimiz view olusturduk 
        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }
    }
}
