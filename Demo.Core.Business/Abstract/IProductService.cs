using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Business.Abstract
{
    public interface IProductService
    {
        Products GetByID(int productID);
        List<Products> GetAll();
        List<Products> GetByCategory(int categoryID);
        void Add(Products product);
        void Delete(int productID);
        void Update(Products product);

    }
}
