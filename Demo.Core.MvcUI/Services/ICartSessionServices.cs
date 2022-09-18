using Demo.Core.Entities.Concrete;

namespace Demo.Core.MvcUI.Services
{
    public interface ICartSessionServices
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
