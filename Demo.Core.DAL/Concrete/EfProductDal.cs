using Demo.Core.DAL.Abstract;
using Demo.Core.DAL.EntityFramework;
using Demo.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.DAL.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Products>, IProductDal
    {

        public EfProductDal(NorthwindContext northwindContext) : base(northwindContext)
        {
        }

    }
}
