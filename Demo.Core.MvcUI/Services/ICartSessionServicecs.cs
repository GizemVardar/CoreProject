using Demo.Core.Entities.Concrete;

namespace Demo.Core.MvcUI.Services
{
    public interface ICartSessionServicecs
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
