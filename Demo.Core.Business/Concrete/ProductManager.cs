using Demo.Core.Business.Abstract;
using Demo.Core.DAL.Abstract;
using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Products product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productID)
        {
            Products products = GetByID(productID);
            _productDal.Delete(products);
        }

        public List<Products> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Products> GetByCategory(int categoryID)
        {
            return _productDal.GetList(p => p.CategoryID == categoryID);
        }

        public Products GetByID(int productID)
        {
            return _productDal.Get(p => p.ProductID == productID);
        }

        public void Update(Products product)
        {
            _productDal.Update(product);
        }
    }
}
