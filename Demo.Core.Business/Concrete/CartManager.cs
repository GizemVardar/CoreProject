using Demo.Core.Business.Abstract;
using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Core.Business.Concrete
{
    public class CartManager : ICartService
    {
        //Sepete Ekle
        public void AddToCart(Cart cart, Products products)
        {
            // secilen urun Id eşit ise git sepete o ürünü gonder.
            CartLine cartLine = cart.CartLine.FirstOrDefault(x => x.Products.ProductID == products.ProductID);
            if (cartLine!=null)
            {
                cartLine.Quantity++; // sepete bir bir ürün miktarı arttırmak icin yazdık
                return;
            }
            // ilgili ürünü 1 birim olarak ekle.
            cart.CartLine.Add(new CartLine { Products = products, Quantity = 1 });
        }

        //Sepeti Listele
        public List<CartLine> List(Cart cart)
        {
            return cart.CartLine;
        }
        //Sepetten Cıkart 
        public void RemoveToCart(Cart cart, int productID)
        {
            //ürünü sepetten cıkarttır. 
            cart.CartLine.Remove(cart.CartLine.FirstOrDefault(x => x.Products.ProductID == productID));
        }
    }
}
